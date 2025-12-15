using System.Text.Json.Serialization;

namespace Demo.Common.Models;

/// <summary>
/// Classe base per il contenuto multimediale.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "kind", UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
[JsonDerivedType(typeof(DocumentContent), "document")]
[JsonDerivedType(typeof(AudioVisualContent), "audioVisual")]
public class MediaContent
{
    /// <summary>
    /// L'analizzatore che ha generato questo contenuto.
    /// </summary>
    public string? AnalyzerId { get; init; }

    /// <summary>
    /// Categoria di contenuto classificata.
    /// </summary>
    public string? Category { get; init; }

    /// <summary>
    /// Campi estratti dal contenuto.
    /// </summary>
    public Dictionary<string, ContentField>? Fields { get; init; }

    /// <summary>
    /// Rappresentazione Markdown del contenuto.
    /// </summary>
    public string? Markdown { get; init; }

    /// <summary>
    /// Tipo MIME rilevato del contenuto. Es. application/pdf, image/jpeg, ecc.
    /// </summary>
    public string? MimeType { get; init; }

    /// <summary>
    /// Il percorso del contenuto nell'input.
    /// </summary>
    public string? Path { get; init; }
}
