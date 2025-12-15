namespace Demo.Common.Models;

/// <summary>
/// Sorgente di conoscenza da dati etichettati
/// </summary>
public class LabeledDataKnowledgeSource : KnowledgeSource
{
    /// <summary>
    /// L'URL del contenitore blob contenente dati etichettati
    /// </summary>
    public required Uri ContainerUrl { get; init; }

    /// <summary>
    /// Un prefisso facoltativo per filtrare i blob all'interno del contenitore
    /// </summary>
    public string? Prefix { get; init; }

    /// <summary>
    /// Un percorso facoltativo a un file con l'elenco di specifici blob da includere
    /// </summary>
    public string? FileListPath { get; init; }
}
