namespace Demo.Common.Models;

/// <summary>
/// Ubicazione in cui i dati possono essere elaborati
/// </summary>
public enum ProcessingLocation
{
    /// <summary>
    /// I dati possono essere elaborati nella stessa geografia della risorsa
    /// </summary>
    Geography,

    /// <summary>
    /// I dati possono essere elaborati nella stessa zona di dati della risorsa
    /// </summary>
    DataZone,

    /// <summary>
    /// I dati possono essere elaborati in qualsiasi data center Azure a livello globale
    /// </summary>
    Global,
}
