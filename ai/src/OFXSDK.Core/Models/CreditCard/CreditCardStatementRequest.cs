using System;

namespace OFXSDK.Core.Models.CreditCard;

/// <summary>
/// Represents a credit card statement request
/// </summary>
public class CreditCardStatementRequest
{
    /// <summary>
    /// Gets or sets the account information
    /// </summary>
    public CreditCardAccountInfo AccountInfo { get; set; } = new CreditCardAccountInfo();
    
    /// <summary>
    /// Gets or sets the start date for the requested statement
    /// </summary>
    public DateTime? StartDate { get; set; }
    
    /// <summary>
    /// Gets or sets the end date for the requested statement
    /// </summary>
    public DateTime? EndDate { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether to include transactions
    /// </summary>
    public bool IncludeTransactions { get; set; } = true;
    
    /// <summary>
    /// Gets or sets a value indicating whether to include pending transactions
    /// </summary>
    public bool IncludePendingTransactions { get; set; }
}