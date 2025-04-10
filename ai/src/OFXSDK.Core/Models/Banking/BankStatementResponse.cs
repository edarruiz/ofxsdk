using System;
using System.Collections.Generic;

namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Response containing bank statement information
/// </summary>
public class BankStatementResponse
{
    /// <summary>
    /// Transaction unique identifier (must match the request ID)
    /// </summary>
    public string TransactionId { get; set; } = string.Empty;
    
    /// <summary>
    /// Status information for the statement request
    /// </summary>
    public Status Status { get; set; } = new Status();
    
    /// <summary>
    /// Account information 
    /// </summary>
    public BankAccountInfo AccountInfo { get; set; } = new BankAccountInfo();
    
    /// <summary>
    /// Start date for the returned transactions
    /// </summary>
    public DateTime StartDate { get; set; }
    
    /// <summary>
    /// End date for the returned transactions
    /// </summary>
    public DateTime EndDate { get; set; }
    
    /// <summary>
    /// List of transactions in the statement
    /// </summary>
    public List<BankTransaction> Transactions { get; set; } = new List<BankTransaction>();
}