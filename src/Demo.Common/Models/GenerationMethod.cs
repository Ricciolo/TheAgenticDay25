namespace Demo.Common.Models;

/// <summary>
/// Metodo di generazione
/// </summary>
public enum GenerationMethod
{
    /// <summary>
    /// I valori vengono generati liberamente in base al contenuto
    /// </summary>
    Generate,

    /// <summary>
    /// I valori vengono estratti cos� come appaiono nel contenuto
    /// </summary>
    Extract,

    /// <summary>
    /// I valori vengono classificati rispetto a un insieme predefinito di categorie
    /// </summary>
    Classify,
}
