namespace Demo.Common.Models;

/// <summary>
/// Input aggiuntivo da analizzare
/// </summary>
public class AnalyzeInput
{
    /// <summary>
    /// URL dell'input da analizzare. Solo uno tra url o data deve essere specificato
    /// </summary>
    public string? Url { get; init; }

    /// <summary>
    /// Contenuto binario codificato in Base64 dell'input da analizzare. Solo uno tra url o data deve essere specificato
    /// </summary>
    public string? Data { get; init; }

    /// <summary>
    /// Tipo MIME del contenuto dell'input. Es. application/pdf, image/jpeg, ecc
    /// </summary>
    public string? MimeType { get; init; }

    /// <summary>
    /// Nome dell'input
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Intervallo dell'input da analizzare (es. 1-3,5,9-). 
    /// Il contenuto dei documenti utilizza numeri di pagina a base 1, mentre il contenuto audio-visivo utilizza millisecondi interi
    /// </summary>
    public string? Range { get; init; }
}
