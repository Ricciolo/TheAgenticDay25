using System.ComponentModel;
using Demo.Common;
using Demo.Common.Models;
using Demo.Scontrini.Mcp.Models;
using ModelContextProtocol.Server;

namespace Demo.Scontrini.Mcp.McpServer;

/// <summary>
/// Strumento MCP per l'analisi di ricevute utilizzando Azure Content Understanding
/// </summary>
[McpServerToolType]
public class ReceiptMcpTool(IContentUnderstandingApi contentUnderstandingApi)
{
    private const string AnalyzerId = "scontrini";

    /// <summary>
    /// Legge e analizza una ricevuta da un URL di immagine. Restituisce i dettagli della ricevuta come totale, data, articoli.
    /// </summary>
    [McpServerTool, Description("Legge e analizza una ricevuta da un URL di immagine. Restituisce i dettagli della ricevuta come totale, data, articoli.")]
    public async Task<ReceiptResult> ReadReceiptAsync(
        [Description("URL dell'immagine della ricevuta da analizzare")] string imageUrl,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(imageUrl);

        // Valida il formato dell'URL
        if (!Uri.TryCreate(imageUrl, UriKind.Absolute, out var uri) ||
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            return new ReceiptResult
            {
                Success = false,
                Error = "Formato URL non valido. Fornire un URL HTTP o HTTPS valido."
            };
        }

        // Crea la richiesta di analisi con l'URL
        var request = new AnalyzeRequest
        {
            Inputs =
            [
                new AnalyzeInput
                {
                    Url = imageUrl
                }
            ]
        };

        // Avvia l'analisi asincrona
        var analyzeOperation = await contentUnderstandingApi.AnalyzeAsync(
            AnalyzerId,
            request,
            cancellationToken: cancellationToken);

        // Polling per il completamento
        ContentAnalyzerAnalyzeOperationStatus result;
        do
        {
            await Task.Delay(500, cancellationToken);
            result = await contentUnderstandingApi.GetResultAsync(
                analyzeOperation.Id,
                cancellationToken);
        }
        while (result.Status == OperationState.Running);

        // Gestisce gli errori
        if (result.Status == OperationState.Failed)
        {
            return new ReceiptResult
            {
                Success = false,
                Error = result.Error?.Message ?? "Errore durante l'analisi della ricevuta"
            };
        }

        // Estrae i dati dal risultato
        return ExtractReceiptData(result);
    }

    /// <summary>
    /// Estrae i dati della ricevuta dal risultato dell'analisi
    /// </summary>
    private static ReceiptResult ExtractReceiptData(ContentAnalyzerAnalyzeOperationStatus result)
    {
        if (result.Result?.Contents?.FirstOrDefault() is not DocumentContent documentContent)
        {
            return new ReceiptResult
            {
                Success = false,
                Error = "Nessun contenuto trovato nel risultato dell'analisi"
            };
        }

        var fields = documentContent.Fields;
        if (fields == null)
        {
            return new ReceiptResult
            {
                Success = true,
                Error = "Campi strutturati non disponibili, ma il documento è stato analizzato"
            };
        }

        // Estrae i campi della ricevuta utilizzando i nomi effettivi dell'analyzer
        var receiptResult = new ReceiptResult
        {
            Success = true,
            Date = ExtractDateField(fields, "InvoiceDate"),
            TotalAmount = ExtractNumberField(fields, "TotalAmount"),
            TaxRate = ExtractNumberField(fields, "TaxRate"),
            TaxAmount = ExtractNumberField(fields, "TaxAmount"),
            Items = ExtractItems(fields)
        };

        return receiptResult;
    }

    /// <summary>
    /// Estrae un campo stringa dai campi estratti
    /// </summary>
    private static string? ExtractStringField(Dictionary<string, ContentField> fields, params string[] possibleNames)
    {
        foreach (var name in possibleNames)
        {
            if (fields.TryGetValue(name, out var field) && field is StringField stringField)
            {
                return stringField.ValueString;
            }
        }
        return null;
    }

    /// <summary>
    /// Estrae un campo data dai campi estratti
    /// </summary>
    private static string? ExtractDateField(Dictionary<string, ContentField> fields, string fieldName)
    {
        if (fields.TryGetValue(fieldName, out var field) && field is DateField dateField)
        {
            return dateField.ValueDate;
        }

        return null;
    }

    /// <summary>
    /// Estrae un campo numerico dai campi estratti
    /// </summary>
    private static double? ExtractNumberField(Dictionary<string, ContentField> fields, params string[] possibleNames)
    {
        foreach (var name in possibleNames)
        {
            if (fields.TryGetValue(name, out var field) && field is NumberField numberField)
            {
                return numberField.ValueNumber;
            }
        }
        return null;
    }

    /// <summary>
    /// Estrae la lista degli articoli dalla ricevuta
    /// </summary>
    private static List<ReceiptItem>? ExtractItems(Dictionary<string, ContentField> fields)
    {
        if (fields.TryGetValue("Items", out var field) && field is ArrayField arrayField && arrayField.ValueArray != null)
        {
            var items = new List<ReceiptItem>();

            foreach (var item in arrayField.ValueArray)
            {
                if (item is ObjectField objectField && objectField.ValueObject != null)
                {
                    // Crea un articolo della ricevuta dai campi estratti
                    var receiptItem = new ReceiptItem
                    {
                        Description = ExtractStringField(objectField.ValueObject, "Description"),
                        Quantity = ExtractNumberField(objectField.ValueObject, "Quantity"),
                        Price = ExtractNumberField(objectField.ValueObject, "Price"),
                    };
                    items.Add(receiptItem);
                }
            }

            return items.Count > 0 ? items : null;
        }

        return null;
    }
}
