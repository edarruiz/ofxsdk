using System;

namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Represents account balance information
/// </summary>
public class BalanceInfo
{
    /// <summary>
    /// Gets or sets the ledger balance amount
    /// </summary>
    public decimal LedgerBalance { get; set; }

    /// <summary>
    /// Gets or sets the date of the ledger balance
    /// </summary>
    public DateTime LedgerBalanceDate { get; set; }

    /// <summary>
    /// Gets or sets the available balance amount
    /// </summary>
    public decimal AvailableBalance { get; set; }

    /// <summary>
    /// Gets or sets the date of the available balance
    /// </summary>
    public DateTime AvailableBalanceDate { get; set; }
}