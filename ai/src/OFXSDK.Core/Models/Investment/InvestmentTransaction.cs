using System;

namespace OFXSDK.Core.Models.Investment;

/// <summary>
/// Represents an investment transaction
/// </summary>
public class InvestmentTransaction
{
    /// <summary>
    /// Gets or sets the transaction ID
    /// </summary>
    public string TransactionId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the transaction type (BUY, SELL, DIV, etc.)
    /// </summary>
    public string TransactionType { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date posted
    /// </summary>
    public DateTime DatePosted { get; set; }

    /// <summary>
    /// Gets or sets the transaction date
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Gets or sets the security information
    /// </summary>
    public SecurityInfo Security { get; set; } = new SecurityInfo();

    /// <summary>
    /// Gets or sets the number of units in the transaction
    /// </summary>
    public decimal Units { get; set; }

    /// <summary>
    /// Gets or sets the unit price
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the total amount of the transaction
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets any commission paid
    /// </summary>
    public decimal Commission { get; set; }

    /// <summary>
    /// Gets or sets any fees paid
    /// </summary>
    public decimal Fees { get; set; }

    /// <summary>
    /// Gets or sets the memo or note associated with the transaction
    /// </summary>
    public string Memo { get; set; } = string.Empty;
}