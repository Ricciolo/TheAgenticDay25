using Demo.Common.Models;
using Refit;

namespace Demo.Common;

/// <summary>
/// Interfaccia Refit per l'API Content Understanding - endpoint Content Analyzers
/// </summary>
public interface IContentUnderstandingApi
{
    /// <summary>
    /// Elenca gli analyzer disponibili
    /// </summary>
    /// <param name="cancellationToken">Token di cancellazione</param>
    /// <returns>Collezione paginata di elementi ContentAnalyzer</returns>
    [Get("/contentunderstanding/analyzers?api-version=2025-11-01")]
    Task<PagedContentAnalyzer> ListAnalyzersAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Analizza il contenuto binario di un documento utilizzando l'analyzer specificato
    /// </summary>
    /// <param name="analyzerId">Identificatore univoco dell'analyzer</param>
    /// <param name="content">Contenuto binario del documento da analizzare</param>
    /// <param name="stringEncoding">Formato di codifica delle stringhe nella risposta (codePoint, utf16, utf8). Default: codePoint</param>
    /// <param name="processingLocation">Ubicazione dove i dati possono essere elaborati (geography, dataZone, global). Default: global</param>
    /// <param name="range">Intervallo dell'input da analizzare (es. 1-3,5,9-)</param>
    /// <param name="cancellationToken">Token di cancellazione</param>
    /// <returns>Risultato dell'operazione con ID tracciamento</returns>
    [Post("/contentunderstanding/analyzers/{analyzerId}:analyzeBinary?api-version=2025-11-01")]
    Task<AnalyzeOperation> AnalyzeBinaryAsync(
        string analyzerId,
        [Body] Stream content,
        [Query] string? stringEncoding = null,
        [Query] string? processingLocation = null,
        [Query] string? range = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Crea un nuovo analyzer in modo asincrono o sostituisce uno esistente
    /// </summary>
    /// <param name="analyzerId">Identificatore univoco dell'analyzer</param>
    /// <param name="analyzer">Definizione dell'analyzer da creare o aggiornare</param>
    /// <param name="allowReplace">Consente all'operazione di sostituire una risorsa esistente</param>
    /// <param name="cancellationToken">Token di cancellazione</param>
    /// <returns>Analyzer creato con lo stato dell'operazione asincrona nell'header Operation-Location</returns>
    [Put("/contentunderstanding/analyzers/{analyzerId}?api-version=2025-11-01")]
    Task<ContentAnalyzer> CreateOrReplaceAsync(
        string analyzerId,
        [Body] ContentAnalyzer analyzer,
        [Query] bool? allowReplace = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Ottiene lo stato di un'operazione di creazione di un analyzer
    /// </summary>
    /// <param name="analyzerId">Identificatore univoco dell'analyzer</param>
    /// <param name="operationId">Identificatore univoco dell'operazione</param>
    /// <param name="cancellationToken">Token di cancellazione</param>
    /// <returns>Stato dettagliato dell'operazione di creazione dell'analyzer</returns>
    [Get("/contentunderstanding/analyzers/{analyzerId}/operations/{operationId}?api-version=2025-11-01")]
    Task<ContentAnalyzerOperationStatus> GetOperationStatusAsync(
        string analyzerId,
        string operationId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Ottiene il risultato di un'operazione di analisi di un documento
    /// </summary>
    /// <param name="operationId">Identificatore univoco dell'operazione</param>
    /// <param name="cancellationToken">Token di cancellazione</param>
    /// <returns>Risultato dell'operazione di analisi con dettagli completi</returns>
    [Get("/contentunderstanding/analyzerResults/{operationId}?api-version=2025-11-01")]
    Task<ContentAnalyzerAnalyzeOperationStatus> GetResultAsync(
        string operationId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Analizza il contenuto di documenti (URL o binario) utilizzando l'analyzer specificato
    /// </summary>
    /// <param name="analyzerId">Identificatore univoco dell'analyzer</param>
    /// <param name="request">Richiesta di analisi con input (URL o dati binari) da analizzare</param>
    /// <param name="stringEncoding">Formato di codifica delle stringhe nella risposta (codePoint, utf16, utf8). Default: codePoint</param>
    /// <param name="processingLocation">Ubicazione dove i dati possono essere elaborati (geography, dataZone, global). Default: global</param>
    /// <param name="cancellationToken">Token di cancellazione</param>
    /// <returns>Risultato dell'operazione con ID tracciamento</returns>
    [Post("/contentunderstanding/analyzers/{analyzerId}:analyze?api-version=2025-11-01")]
    Task<AnalyzeOperation> AnalyzeAsync(
        string analyzerId,
        [Body] AnalyzeRequest request,
        [Query] string? stringEncoding = null,
        [Query] string? processingLocation = null,
        CancellationToken cancellationToken = default);
}
