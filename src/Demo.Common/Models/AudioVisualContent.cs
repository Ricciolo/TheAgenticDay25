using System.Text.Json;

namespace Demo.Common.Models;

/// <summary>
/// Contenuto audio visivo. Es. audio/wav, video/mp4.
/// </summary>
public class AudioVisualContent : MediaContent
{
    /// <summary>
    /// Elenco dei cambiamenti di scena della videocamera nel video, rappresentati dal timestamp in millisecondi. Solo se returnDetails è true.
    /// </summary>
    public List<long>? CameraShotTimesMs { get; init; }

    /// <summary>
    /// Tempo di fine del contenuto in millisecondi.
    /// </summary>
    public long? EndTimeMs { get; init; }

    /// <summary>
    /// Altezza di ogni fotogramma video in pixel, se applicabile.
    /// </summary>
    public int? Height { get; init; }

    /// <summary>
    /// Elenco dei fotogrammi chiave nel video, rappresentati dal timestamp in millisecondi. Solo se returnDetails è true.
    /// </summary>
    public List<long>? KeyFrameTimesMs { get; init; }

    /// <summary>
    /// Tipo MIME rilevato del contenuto. Es. application/pdf, image/jpeg, ecc.
    /// </summary>
    public string? MimeType { get; init; }

    /// <summary>
    /// Il percorso del contenuto nell'input.
    /// </summary>
    public string? Path { get; init; }

    /// <summary>
    /// Tempo di inizio del contenuto in millisecondi.
    /// </summary>
    public long? StartTimeMs { get; init; }

    /// <summary>
    /// Elenco delle frasi trascritte. Solo se returnDetails è true.
    /// </summary>
    public List<TranscriptPhrase>? TranscriptPhrases { get; init; }

    /// <summary>
    /// Larghezza di ogni fotogramma video in pixel, se applicabile.
    /// </summary>
    public int? Width { get; init; }
}

/// <summary>
/// Segmento di contenuto audio/visivo rilevato.
/// </summary>
public class AudioVisualContentSegment
{
    /// <summary>
    /// Categoria di contenuto classificata.
    /// </summary>
    public string? Category { get; init; }

    /// <summary>
    /// Tempo di fine del segmento in millisecondi.
    /// </summary>
    public long? EndTimeMs { get; init; }

    /// <summary>
    /// Identificatore del segmento.
    /// </summary>
    public string? SegmentId { get; init; }

    /// <summary>
    /// Intervallo del segmento nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }

    /// <summary>
    /// Tempo di inizio del segmento in millisecondi.
    /// </summary>
    public long? StartTimeMs { get; init; }
}

/// <summary>
/// Frase della trascrizione.
/// </summary>
public class TranscriptPhrase
{
    /// <summary>
    /// Confidenza della previsione della frase.
    /// </summary>
    public double? Confidence { get; init; }

    /// <summary>
    /// Tempo di fine della frase in millisecondi.
    /// </summary>
    public long? EndTimeMs { get; init; }

    /// <summary>
    /// Locale rilevato della frase. Es. en-US.
    /// </summary>
    public string? Locale { get; init; }

    /// <summary>
    /// Intervallo della frase nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }

    /// <summary>
    /// Indice o nome dell'oratore.
    /// </summary>
    public string? Speaker { get; init; }

    /// <summary>
    /// Tempo di inizio della frase in millisecondi.
    /// </summary>
    public long? StartTimeMs { get; init; }

    /// <summary>
    /// Testo della trascrizione.
    /// </summary>
    public string? Text { get; init; }

    /// <summary>
    /// Elenco delle parole nella frase.
    /// </summary>
    public List<TranscriptWord>? Words { get; init; }
}

/// <summary>
/// Parola della trascrizione.
/// </summary>
public class TranscriptWord
{
    /// <summary>
    /// Tempo di fine della parola in millisecondi.
    /// </summary>
    public long? EndTimeMs { get; init; }

    /// <summary>
    /// Intervallo della parola nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }

    /// <summary>
    /// Tempo di inizio della parola in millisecondi.
    /// </summary>
    public long? StartTimeMs { get; init; }

    /// <summary>
    /// Testo della trascrizione.
    /// </summary>
    public string? Text { get; init; }
}
