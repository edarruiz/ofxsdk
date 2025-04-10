namespace OFXSDK.Core.Models.Investment;

/// <summary>
/// Represents security information
/// </summary>
public class SecurityInfo
{
    /// <summary>
    /// Gets or sets the unique ID of the security
    /// </summary>
    public string UniqueId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ID type (CUSIP, SEDOL, TICKER, etc.)
    /// </summary>
    public string UniqueIdType { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the security name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ticker symbol
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the security type (STOCK, BOND, MUFUND, etc.)
    /// </summary>
    public string SecurityType { get; set; } = string.Empty;
}