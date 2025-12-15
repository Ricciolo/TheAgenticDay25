namespace Demo.Common.Models;

/// <summary>
/// Formato di rappresentazione dei grafici nel markdown del risultato dell'analisi
/// </summary>
public enum ChartFormat
{
    /// <summary>
    /// Rappresenta i grafici come blocchi di codice Chart.js
    /// </summary>
    ChartJs,

    /// <summary>
    /// Rappresenta i grafici come tabelle markdown
    /// </summary>
    Markdown,
}
