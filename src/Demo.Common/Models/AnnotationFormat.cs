namespace Demo.Common.Models;

/// <summary>
/// Formato di rappresentazione delle annotazioni nel markdown del risultato dell'analisi
/// </summary>
public enum AnnotationFormat
{
    /// <summary>
    /// Non rappresenta le annotazioni
    /// </summary>
    None,

    /// <summary>
    /// Rappresenta le informazioni di annotazione di base usando la formattazione markdown
    /// </summary>
    Markdown,
}
