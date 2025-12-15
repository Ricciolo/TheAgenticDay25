using System.Text.Json;

namespace Demo.Common.Models;

/// <summary>
/// Contenuto del documento. Es. text/plain, application/pdf, image/jpeg.
/// </summary>
public class DocumentContent : MediaContent
{
    /// <summary>
    /// Elenco delle annotazioni nel documento. Solo se enableAnnotations e returnDetails sono true.
    /// </summary>
    public List<DocumentAnnotation>? Annotations { get; init; }

    /// <summary>
    /// Numero della pagina finale (indicizzato a 1) del contenuto.
    /// </summary>
    public int? EndPageNumber { get; init; }

    /// <summary>
    /// Elenco delle figure nel documento. Solo se enableLayout e returnDetails sono true.
    /// </summary>
    public List<JsonElement>? Figures { get; init; }

    /// <summary>
    /// Elenco dei collegamenti ipertestuali nel documento. Solo se returnDetails è true.
    /// </summary>
    public List<DocumentHyperlink>? Hyperlinks { get; init; }

    /// <summary>
    /// Elenco delle pagine nel documento.
    /// </summary>
    public List<DocumentPage>? Pages { get; init; }

    /// <summary>
    /// Elenco dei paragrafi nel documento. Solo se enableOcr e returnDetails sono true.
    /// </summary>
    public List<DocumentParagraph>? Paragraphs { get; init; }

    /// <summary>
    /// Elenco delle sezioni nel documento. Solo se enableLayout e returnDetails sono true.
    /// </summary>
    public List<DocumentSection>? Sections { get; init; }

    /// <summary>
    /// Elenco dei segmenti di contenuto rilevati. Solo se enableSegment è true.
    /// </summary>
    public List<DocumentContentSegment>? Segments { get; init; }

    /// <summary>
    /// Numero della pagina iniziale (indicizzato a 1) del contenuto.
    /// </summary>
    public int? StartPageNumber { get; init; }

    /// <summary>
    /// Elenco delle tabelle nel documento. Solo se enableLayout e returnDetails sono true.
    /// </summary>
    public List<DocumentTable>? Tables { get; init; }

    /// <summary>
    /// Unità di lunghezza utilizzata dalle proprietà width, height e source. Per images/tiff, l'unità predefinita è pixel. Per PDF, l'unità predefinita è inch.
    /// </summary>
    public string? Unit { get; init; }
}

/// <summary>
/// Contenuto da una pagina del documento.
/// </summary>
public class DocumentPage
{
    /// <summary>
    /// L'orientamento generale del contenuto in senso orario, misurato in gradi tra (-180, 180]. Solo se enableOcr è true.
    /// </summary>
    public double? Angle { get; init; }

    /// <summary>
    /// Elenco dei codici a barre nella pagina. Solo se enableBarcode e returnDetails sono true.
    /// </summary>
    public List<DocumentBarcode>? Barcodes { get; init; }

    /// <summary>
    /// Elenco delle formule matematiche nella pagina. Solo se enableFormula e returnDetails sono true.
    /// </summary>
    public List<DocumentFormula>? Formulas { get; init; }

    /// <summary>
    /// Altezza della pagina.
    /// </summary>
    public double? Height { get; init; }

    /// <summary>
    /// Elenco delle righe nella pagina. Solo se enableOcr e returnDetails sono true.
    /// </summary>
    public List<DocumentLine>? Lines { get; init; }

    /// <summary>
    /// Numero di pagina (basato su 1).
    /// </summary>
    public int? PageNumber { get; init; }

    /// <summary>
    /// Intervallo/i associato/i alla pagina nel contenuto markdown.
    /// </summary>
    public List<ContentSpan>? Spans { get; init; }

    /// <summary>
    /// Larghezza della pagina.
    /// </summary>
    public double? Width { get; init; }

    /// <summary>
    /// Elenco delle parole nella pagina. Solo se enableOcr e returnDetails sono true.
    /// </summary>
    public List<DocumentWord>? Words { get; init; }
}

/// <summary>
/// Parola in un documento.
/// </summary>
public class DocumentWord
{
    /// <summary>
    /// Confidenza della previsione della parola.
    /// </summary>
    public double? Confidence { get; init; }

    /// <summary>
    /// Testo della parola.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// Sorgente codificata che identifica la posizione della parola nel contenuto.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervallo della parola nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }
}

/// <summary>
/// Riga in un documento.
/// </summary>
public class DocumentLine
{
    /// <summary>
    /// Testo della riga.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// Sorgente codificata che identifica la posizione della riga nel contenuto.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervallo della riga nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }
}

/// <summary>
/// Codice a barre in un documento.
/// </summary>
public class DocumentBarcode
{
    /// <summary>
    /// Confidenza della previsione del codice a barre.
    /// </summary>
    public double? Confidence { get; init; }

    /// <summary>
    /// Tipo di codice a barre.
    /// </summary>
    public string? Kind { get; init; }

    /// <summary>
    /// Sorgente codificata che identifica la posizione del codice a barre nel contenuto.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervallo del codice a barre nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }

    /// <summary>
    /// Valore del codice a barre.
    /// </summary>
    public string? Value { get; init; }
}

/// <summary>
/// Formula matematica in un documento.
/// </summary>
public class DocumentFormula
{
    /// <summary>
    /// Confidenza della previsione della formula.
    /// </summary>
    public double? Confidence { get; init; }

    /// <summary>
    /// Tipo di formula.
    /// </summary>
    public string? Kind { get; init; }

    /// <summary>
    /// Sorgente codificata che identifica la posizione della formula nel contenuto.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervallo della formula nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }

    /// <summary>
    /// Espressione LaTex che descrive la formula.
    /// </summary>
    public string? Value { get; init; }
}

/// <summary>
/// Paragrafo in un documento.
/// </summary>
public class DocumentParagraph
{
    /// <summary>
    /// Testo del paragrafo.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// Ruolo semantico del paragrafo.
    /// </summary>
    public string? Role { get; init; }

    /// <summary>
    /// Sorgente codificata che identifica la posizione del paragrafo nel contenuto.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervallo del paragrafo nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }
}

/// <summary>
/// Sezione in un documento.
/// </summary>
public class DocumentSection
{
    /// <summary>
    /// Elementi figlio della sezione.
    /// </summary>
    public List<string>? Elements { get; init; }

    /// <summary>
    /// Intervallo della sezione nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }
}

/// <summary>
/// Tabella in un documento.
/// </summary>
public class DocumentTable
{
    /// <summary>
    /// Didascalia della tabella.
    /// </summary>
    public DocumentCaption? Caption { get; init; }

    /// <summary>
    /// Celle contenute nella tabella.
    /// </summary>
    public List<DocumentTableCell>? Cells { get; init; }

    /// <summary>
    /// Numero di colonne nella tabella.
    /// </summary>
    public int? ColumnCount { get; init; }

    /// <summary>
    /// Elenco delle note a piè di pagina della tabella.
    /// </summary>
    public List<DocumentFootnote>? Footnotes { get; init; }

    /// <summary>
    /// Ruolo semantico della tabella.
    /// </summary>
    public string? Role { get; init; }

    /// <summary>
    /// Numero di righe nella tabella.
    /// </summary>
    public int? RowCount { get; init; }

    /// <summary>
    /// Sorgente codificata che identifica la posizione della tabella nel contenuto.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervallo della tabella nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }
}

/// <summary>
/// Cella di tabella in una tabella del documento.
/// </summary>
public class DocumentTableCell
{
    /// <summary>
    /// Indice di colonna della cella.
    /// </summary>
    public int? ColumnIndex { get; init; }

    /// <summary>
    /// Numero di colonne occupate da questa cella.
    /// </summary>
    public int? ColumnSpan { get; init; }

    /// <summary>
    /// Contenuto della cella della tabella.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// Elementi figlio della cella della tabella.
    /// </summary>
    public List<string>? Elements { get; init; }

    /// <summary>
    /// Tipo di cella della tabella.
    /// </summary>
    public string? Kind { get; init; }

    /// <summary>
    /// Indice di riga della cella.
    /// </summary>
    public int? RowIndex { get; init; }

    /// <summary>
    /// Numero di righe occupate da questa cella.
    /// </summary>
    public int? RowSpan { get; init; }

    /// <summary>
    /// Sorgente codificata che identifica la posizione della cella della tabella nel contenuto.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervallo della cella della tabella nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }
}

/// <summary>
/// Didascalia di una tabella o figura.
/// </summary>
public class DocumentCaption
{
    /// <summary>
    /// Contenuto della didascalia.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// Elementi figlio della didascalia.
    /// </summary>
    public List<string>? Elements { get; init; }

    /// <summary>
    /// Sorgente codificata che identifica la posizione della didascalia nel contenuto.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervallo della didascalia nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }
}

/// <summary>
/// Nota a piè di pagina di una tabella o figura.
/// </summary>
public class DocumentFootnote
{
    /// <summary>
    /// Contenuto della nota a piè di pagina.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// Elementi figlio della nota a piè di pagina.
    /// </summary>
    public List<string>? Elements { get; init; }

    /// <summary>
    /// Sorgente codificata che identifica la posizione della nota a piè di pagina nel contenuto.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervallo della nota a piè di pagina nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }
}

/// <summary>
/// Collegamento ipertestuale in un documento.
/// </summary>
public class DocumentHyperlink
{
    /// <summary>
    /// Contenuto collegato ipertestualmente.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// Posizione del collegamento ipertestuale.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervallo del collegamento ipertestuale nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }

    /// <summary>
    /// URL del collegamento ipertestuale.
    /// </summary>
    public string? Url { get; init; }
}

/// <summary>
/// Annotazione in un documento.
/// </summary>
public class DocumentAnnotation
{
    /// <summary>
    /// Autore dell'annotazione.
    /// </summary>
    public string? Author { get; init; }

    /// <summary>
    /// Commenti associati all'annotazione.
    /// </summary>
    public List<DocumentAnnotationComment>? Comments { get; init; }

    /// <summary>
    /// Data e ora in cui è stata creata l'annotazione.
    /// </summary>
    public DateTimeOffset? CreatedAt { get; init; }

    /// <summary>
    /// Identificatore dell'annotazione.
    /// </summary>
    public string? Id { get; init; }

    /// <summary>
    /// Tipo di annotazione.
    /// </summary>
    public string? Kind { get; init; }

    /// <summary>
    /// Data e ora in cui l'annotazione è stata modificata l'ultima volta.
    /// </summary>
    public DateTimeOffset? LastModifiedAt { get; init; }

    /// <summary>
    /// Posizione dell'annotazione.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Intervalli del contenuto associati all'annotazione.
    /// </summary>
    public List<ContentSpan>? Spans { get; init; }

    /// <summary>
    /// Tag associati all'annotazione.
    /// </summary>
    public List<string>? Tags { get; init; }
}

/// <summary>
/// Commento associato a un'annotazione del documento.
/// </summary>
public class DocumentAnnotationComment
{
    /// <summary>
    /// Autore del commento.
    /// </summary>
    public string? Author { get; init; }

    /// <summary>
    /// Data e ora in cui è stato creato il commento.
    /// </summary>
    public DateTimeOffset? CreatedAt { get; init; }

    /// <summary>
    /// Data e ora in cui il commento è stato modificato l'ultima volta.
    /// </summary>
    public DateTimeOffset? LastModifiedAt { get; init; }

    /// <summary>
    /// Messaggio del commento in Markdown.
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// Tag associati al commento.
    /// </summary>
    public List<string>? Tags { get; init; }
}

/// <summary>
/// Segmento di contenuto del documento rilevato.
/// </summary>
public class DocumentContentSegment
{
    /// <summary>
    /// Categoria di contenuto classificata.
    /// </summary>
    public string? Category { get; init; }

    /// <summary>
    /// Numero della pagina finale (indicizzato a 1) del segmento.
    /// </summary>
    public int? EndPageNumber { get; init; }

    /// <summary>
    /// Identificatore del segmento.
    /// </summary>
    public string? SegmentId { get; init; }

    /// <summary>
    /// Intervallo del segmento nel contenuto markdown.
    /// </summary>
    public ContentSpan? Span { get; init; }

    /// <summary>
    /// Numero della pagina iniziale (indicizzato a 1) del segmento.
    /// </summary>
    public int? StartPageNumber { get; init; }
}
