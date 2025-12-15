namespace Demo.Common.Models;

/// <summary>
/// Tipo di dato semantico del valore del campo
/// </summary>
public enum ContentFieldType
{
    /// <summary>
    /// Testo semplice
    /// </summary>
    String,

    /// <summary>
    /// Data, normalizzata nel formato ISO 8601 (YYYY-MM-DD)
    /// </summary>
    Date,

    /// <summary>
    /// Ora, normalizzata nel formato ISO 8601 (hh:mm:ss)
    /// </summary>
    Time,

    /// <summary>
    /// Numero a virgola mobile a doppia precisione
    /// </summary>
    Number,

    /// <summary>
    /// Intero a 64 bit con segno
    /// </summary>
    Integer,

    /// <summary>
    /// Valore booleano
    /// </summary>
    Boolean,

    /// <summary>
    /// Elenco di sottocampi dello stesso tipo
    /// </summary>
    Array,

    /// <summary>
    /// Elenco denominato di sottocampi
    /// </summary>
    Object,

    /// <summary>
    /// Oggetto JSON
    /// </summary>
    Json,
}
