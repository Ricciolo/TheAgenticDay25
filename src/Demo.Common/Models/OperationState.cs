namespace Demo.Common.Models;

/// <summary>
/// Lo stato dell'operazione
/// </summary>
public enum OperationState
{
    /// <summary>
    /// L'operazione non è stata avviata
    /// </summary>
    NotStarted,

    /// <summary>
    /// L'operazione è in corso
    /// </summary>
    Running,

    /// <summary>
    /// L'operazione è stata completata con successo
    /// </summary>
    Succeeded,

    /// <summary>
    /// L'operazione non è riuscita
    /// </summary>
    Failed,

    /// <summary>
    /// L'operazione è stata annullata
    /// </summary>
    Canceled
}
