using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;

namespace Demo.Manuals;

/// <summary>
/// Documento indicizzato in Azure Search rappresentante un manuale.
/// </summary>
public class ManualDocument
{
    /// <summary>
    /// Identificatore univoco del documento (basato sul nome del file).
    /// </summary>
    [SimpleField(IsKey = true, IsFilterable = true)]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Nome del file originale.
    /// </summary>
    [SearchableField(IsFilterable = true, IsSortable = true)]
    public string FileName { get; set; } = string.Empty;

    /// <summary>
    /// Titolo della sezione (estratto dal header # o ##).
    /// </summary>
    [SearchableField(IsFilterable = true, IsSortable = true)]
    public string SectionTitle { get; set; } = string.Empty;

    /// <summary>
    /// Indice del chunk all'interno del documento originale.
    /// </summary>
    [SimpleField(IsFilterable = true, IsSortable = true)]
    public int ChunkIndex { get; set; }

    /// <summary>
    /// Contenuto del documento in formato Markdown.
    /// </summary>
    [SearchableField(AnalyzerName = "en.microsoft")]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Data di indicizzazione del documento.
    /// </summary>
    [SimpleField(IsFilterable = true, IsSortable = true)]
    public DateTimeOffset IndexedAt { get; set; }
}
