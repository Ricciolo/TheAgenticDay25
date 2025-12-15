namespace Demo.Common.Models;

/// <summary>
/// Formato di rappresentazione delle tabelle nel markdown del risultato dell'analisi
/// </summary>
public enum TableFormat
{
    /// <summary>
    /// Rappresenta le tabelle usando elementi di tabella HTML: &lt;table&gt;, &lt;th&gt;, &lt;tr&gt;, &lt;td&gt;
    /// </summary>
    Html,

    /// <summary>
    /// Rappresenta le tabelle usando la sintassi della tabella GitHub Flavored Markdown
    /// </summary>
    Markdown,
}
