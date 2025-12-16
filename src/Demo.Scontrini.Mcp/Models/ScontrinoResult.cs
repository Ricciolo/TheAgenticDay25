namespace Demo.Scontrini.Mcp.Models;

/// <summary>
/// Risultato dell'analisi di una ricevuta
/// </summary>
public class ReceiptResult
{
    /// <summary>
    /// Indica se l'analisi è stata completata con successo
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// Messaggio di errore in caso di fallimento
    /// </summary>
    public string? Error { get; init; }

    /// <summary>
    /// Data della fattura/ricevuta
    /// </summary>
    public string? Date { get; init; }

    /// <summary>
    /// Importo totale della ricevuta
    /// </summary>
    public double? TotalAmount { get; init; }

    /// <summary>
    /// Aliquota IVA percentuale
    /// </summary>
    public double? TaxRate { get; init; }

    /// <summary>
    /// Importo dell'IVA
    /// </summary>
    public double? TaxAmount { get; init; }

    /// <summary>
    /// Lista degli articoli acquistati
    /// </summary>
    public List<ReceiptItem>? Items { get; init; }
}

/// <summary>
/// Singolo articolo sulla ricevuta
/// </summary>
public class ReceiptItem
{
    /// <summary>
    /// Descrizione dell'articolo
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Quantità acquistata
    /// </summary>
    public double? Quantity { get; init; }

    /// <summary>
    /// Prezzo unitario
    /// </summary>
    public double? Price { get; init; }
}
