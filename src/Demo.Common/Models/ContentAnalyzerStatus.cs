namespace Demo.Common.Models;

/// <summary>
/// Stato di una risorsa
/// </summary>
public enum ContentAnalyzerStatus
{
    /// <summary>
    /// La risorsa � in fase di creazione
    /// </summary>
    Creating,

    /// <summary>
    /// La risorsa � pronta
    /// </summary>
    Ready,

    /// <summary>
    /// La risorsa � in fase di eliminazione
    /// </summary>
    Deleting,

    /// <summary>
    /// La risorsa non � riuscita durante la creazione
    /// </summary>
    Failed,
}
