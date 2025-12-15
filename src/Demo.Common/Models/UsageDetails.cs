namespace Demo.Common.Models;

/// <summary>
/// Dettagli di utilizzo di un'operazione
/// </summary>
public class UsageDetails
{
    /// <summary>
    /// Le ore di audio elaborate
    /// </summary>
    public double? AudioHours { get; init; }

    /// <summary>
    /// Le ore di video elaborate
    /// </summary>
    public double? VideoHours { get; init; }

    /// <summary>
    /// Il numero di pagine di documenti elaborate a livello base
    /// </summary>
    public int? DocumentPagesBasic { get; init; }

    /// <summary>
    /// Il numero di pagine di documenti elaborate a livello minimo
    /// </summary>
    public int? DocumentPagesMinimal { get; init; }

    /// <summary>
    /// Il numero di pagine di documenti elaborate a livello standard
    /// </summary>
    public int? DocumentPagesStandard { get; init; }

    /// <summary>
    /// Il numero di token di contestualizzazione consumati per preparare il contesto, 
    /// generare punteggi di confidenza, grounding della fonte e formattazione dell'output
    /// </summary>
    public int? ContextualizationTokens { get; init; }

    /// <summary>
    /// Il numero di token LLM e di embedding consumati, raggruppati per modello (es. GPT 4.1) e tipo (es. input, cached input, output)
    /// </summary>
    public Dictionary<string, object>? Tokens { get; init; }
}
