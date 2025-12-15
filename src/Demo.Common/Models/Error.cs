namespace Demo.Common.Models;

/// <summary>
/// Oggetto errore
/// </summary>
public class Error
{
    /// <summary>
    /// Uno dei codici di errore definiti dal server
    /// </summary>
    public string? Code { get; init; }

    /// <summary>
    /// Rappresentazione leggibile dell'errore
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// Target dell'errore
    /// </summary>
    public string? Target { get; init; }

    /// <summary>
    /// Elenco di dettagli su errori specifici che hanno portato a questo errore segnalato
    /// </summary>
    public Error[]? Details { get; init; }
}
