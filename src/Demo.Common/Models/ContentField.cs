using System.Text.Json;
using System.Text.Json.Serialization;

namespace Demo.Common.Models;

/// <summary>
/// Classe base per i campi estratti dal contenuto.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type", UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
[JsonDerivedType(typeof(StringField), "string")]
[JsonDerivedType(typeof(DateField), "date")]
[JsonDerivedType(typeof(TimeField), "time")]
[JsonDerivedType(typeof(NumberField), "number")]
[JsonDerivedType(typeof(IntegerField), "integer")]
[JsonDerivedType(typeof(BooleanField), "boolean")]
[JsonDerivedType(typeof(ArrayField), "array")]
[JsonDerivedType(typeof(ObjectField), "object")]
[JsonDerivedType(typeof(JsonField), "json")]
public class ContentField
{
    /// <summary>
    /// Livello di confidenza della predizione del valore del campo (0-1).
    /// </summary>
    public float? Confidence { get; init; }

    /// <summary>
    /// Sorgente codificata che identifica la posizione del valore del campo nel contenuto.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Span associati al valore del campo nel contenuto markdown.
    /// </summary>
    public List<ContentSpan>? Spans { get; init; }
}

/// <summary>
/// Campo stringa estratto dal contenuto.
/// </summary>
public sealed class StringField : ContentField
{
    /// <summary>
    /// Valore del campo stringa.
    /// </summary>
    public string? ValueString { get; init; }
}

/// <summary>
/// Campo data estratto dal contenuto.
/// </summary>
public sealed class DateField : ContentField
{
    /// <summary>
    /// Valore del campo data, in formato ISO 8601 (YYYY-MM-DD).
    /// </summary>
    public string? ValueDate { get; init; }
}

/// <summary>
/// Campo orario estratto dal contenuto.
/// </summary>
public sealed class TimeField : ContentField
{
    /// <summary>
    /// Valore del campo orario, in formato ISO 8601 (hh:mm:ss).
    /// </summary>
    public string? ValueTime { get; init; }
}

/// <summary>
/// Campo numerico estratto dal contenuto.
/// </summary>
public sealed class NumberField : ContentField
{
    /// <summary>
    /// Valore del campo numerico (double precision).
    /// </summary>
    public double? ValueNumber { get; init; }
}

/// <summary>
/// Campo intero estratto dal contenuto.
/// </summary>
public sealed class IntegerField : ContentField
{
    /// <summary>
    /// Valore del campo intero (64-bit signed).
    /// </summary>
    public long? ValueInteger { get; init; }
}

/// <summary>
/// Campo booleano estratto dal contenuto.
/// </summary>
public sealed class BooleanField : ContentField
{
    /// <summary>
    /// Valore del campo booleano.
    /// </summary>
    public bool? ValueBoolean { get; init; }
}

/// <summary>
/// Campo array estratto dal contenuto.
/// </summary>
public sealed class ArrayField : ContentField
{
    /// <summary>
    /// Valore del campo array.
    /// </summary>
    public List<ContentField>? ValueArray { get; init; }
}

/// <summary>
/// Campo oggetto estratto dal contenuto.
/// </summary>
public sealed class ObjectField : ContentField
{
    /// <summary>
    /// Valore del campo oggetto.
    /// </summary>
    public Dictionary<string, ContentField>? ValueObject { get; init; }
}

/// <summary>
/// Campo JSON estratto dal contenuto.
/// </summary>
public sealed class JsonField : ContentField
{
    /// <summary>
    /// Valore del campo JSON.
    /// </summary>
    public JsonElement? ValueJson { get; init; }
}
