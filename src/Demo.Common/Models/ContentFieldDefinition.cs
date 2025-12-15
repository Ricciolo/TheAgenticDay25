namespace Demo.Common.Models;

/// <summary>
/// Definizione di un campo usando una sintassi simile a JSON Schema
/// </summary>
public class ContentFieldDefinition
{
    /// <summary>
    /// Tipo di dato semantico del valore del campo
    /// </summary>
    public ContentFieldType? Type { get; init; }

    /// <summary>
    /// Descrizione del campo
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Esempi di valori del campo
    /// </summary>
    public string[]? Examples { get; init; }

    /// <summary>
    /// Enumerazione dei possibili valori del campo
    /// </summary>
    public string[]? Enum { get; init; }

    /// <summary>
    /// Descrizioni per ogni valore di enumerazione
    /// </summary>
    public Dictionary<string, string>? EnumDescriptions { get; init; }

    /// <summary>
    /// Riferimento a un'altra definizione di campo
    /// </summary>
    public string? Ref { get; init; }

    /// <summary>
    /// Schema del tipo di campo per ogni elemento della matrice, se il tipo � matrice
    /// </summary>
    public ContentFieldDefinition? Items { get; init; }

    /// <summary>
    /// Sottocampi denominati, se il tipo � oggetto
    /// </summary>
    public Dictionary<string, ContentFieldDefinition>? Properties { get; init; }

    /// <summary>
    /// Metodo di generazione
    /// </summary>
    public GenerationMethod? Method { get; init; }

    /// <summary>
    /// Restituisce la sorgente di grounding e la confidenza
    /// </summary>
    public bool EstimateSourceAndConfidence { get; init; }
}
