using System;

namespace OFXSDK.Core.Models.Investment;

/// <summary>
/// Represents investment balance information
/// </summary>
public class InvestmentBalanceInfo
{
    /// <summary>
    /// Gets or sets the available cash balance
    /// </summary>
    public decimal AvailableCash { get; set; }

    /// <summary>
    /// Gets or sets the margin balance
    /// </summary>
    public decimal MarginBalance { get; set; }

    /// <summary>
    /// Gets or sets the short balance
    /// </summary>
    public decimal ShortBalance { get; set; }

    /// <summary>
    /// Gets or sets the date of the balance information
    /// </summary>
    public DateTime BalanceDate { get; set; }
}