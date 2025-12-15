namespace Demo.Common.Models;

/// <summary>
/// Schema dei campi da estrarre dai documenti
/// </summary>
public class ContentFieldSchema
{
    /// <summary>
    /// Il nome dello schema dei campi
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Una descrizione dello schema dei campi
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// I campi definiti nello schema
    /// </summary>
    public Dictionary<string, ContentFieldDefinition>? Fields { get; init; }

    /// <summary>
    /// Definizioni aggiuntive referenziate dai campi nello schema
    /// </summary>
    public Dictionary<string, ContentFieldDefinition>? Definitions { get; init; }
}
