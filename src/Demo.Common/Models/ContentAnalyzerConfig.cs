namespace Demo.Common.Models;

/// <summary>
/// Impostazioni di configurazione per un analyzer
/// </summary>
public class ContentAnalyzerConfig
{
    /// <summary>
    /// Elenco di hint di locale per la trascrizione vocale
    /// </summary>
    public string[]? Locales { get; init; }

    /// <summary>
    /// Abilita il riconoscimento ottico dei caratteri (OCR)
    /// </summary>
    public bool EnableOcr { get; init; }

    /// <summary>
    /// Abilita l'analisi del layout
    /// </summary>
    public bool EnableLayout { get; init; }

    /// <summary>
    /// Abilita il rilevamento di formule matematiche
    /// </summary>
    public bool EnableFormula { get; init; }

    /// <summary>
    /// Restituisce tutti i dettagli del contenuto
    /// </summary>
    public bool ReturnDetails { get; init; }

    /// <summary>
    /// Abilita l'analisi di figure, come grafici e diagrammi
    /// </summary>
    public bool EnableFigureAnalysis { get; init; }

    /// <summary>
    /// Abilita la generazione di descrizioni di figure
    /// </summary>
    public bool EnableFigureDescription { get; init; }

    /// <summary>
    /// Disabilita l'offuscamento predefinito dei volti per la privacy durante l'elaborazione del contenuto
    /// </summary>
    public bool DisableFaceBlurring { get; init; }

    /// <summary>
    /// Abilita la segmentazione dell'input per contentCategories
    /// </summary>
    public bool EnableSegment { get; init; }

    /// <summary>
    /// Forza la segmentazione del contenuto del documento per pagina
    /// </summary>
    public bool SegmentPerPage { get; init; }

    /// <summary>
    /// Omette il contenuto per questo analyzer dal risultato dell'analisi
    /// </summary>
    public bool OmitContent { get; init; }

    /// <summary>
    /// Restituisce la sorgente di grounding del campo e la confidenza
    /// </summary>
    public bool EstimateFieldSourceAndConfidence { get; init; }

    /// <summary>
    /// Formato di rappresentazione delle tabelle nel markdown del risultato dell'analisi
    /// </summary>
    public TableFormat TableFormat { get; init; } = TableFormat.Html;

    /// <summary>
    /// Formato di rappresentazione dei grafici nel markdown del risultato dell'analisi
    /// </summary>
    public ChartFormat ChartFormat { get; init; } = ChartFormat.ChartJs;

    /// <summary>
    /// Formato di rappresentazione delle annotazioni nel markdown del risultato dell'analisi
    /// </summary>
    public AnnotationFormat AnnotationFormat { get; init; } = AnnotationFormat.Markdown;

    /// <summary>
    /// Mappa di categorie per classificare il contenuto dell'input
    /// </summary>
    public Dictionary<string, ContentCategoryDefinition>? ContentCategories { get; init; }
}
