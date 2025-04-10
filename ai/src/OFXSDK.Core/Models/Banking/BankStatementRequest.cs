using System;
using OFXSDK.Core.Enums;

namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Request for bank statement information
/// </summary>
public class BankStatementRequest
{
    /// <summary>
    /// Transaction unique identifier
    /// </summary>
    public string TransactionId { get; set; } = Guid.NewGuid().ToString();
    
    /// <summary>
    /// Account information to identify the account
    /// </summary>
    public BankAccountId AccountId { get; set; } = new BankAccountId();
    
    /// <summary>
    /// Start date for requested transactions
    /// </summary>
    public DateTime StartDate { get; set; }
    
    /// <summary>
    /// End date for requested transactions
    /// </summary>
    public DateTime? EndDate { get; set; }
    
    /// <summary>
    /// Whether to include transactions or just account information
    /// </summary>
    public bool IncludeTransactions { get; set; } = true;
}