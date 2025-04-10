namespace OFXSDK.Core.Models.Investment;

/// <summary>
/// Represents investment account information
/// </summary>
public class InvestmentAccountInfo
{
    /// <summary>
    /// Gets or sets the account number
    /// </summary>
    public string AccountNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the account description or name
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the broker ID
    /// </summary>
    public string BrokerId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the broker name
    /// </summary>
    public string BrokerName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the account type
    /// </summary>
    public string AccountType { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the tax ID associated with the account
    /// </summary>
    public string TaxId { get; set; } = string.Empty;
}