using System;
using System.Collections.Generic;

namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Response containing bank account information
/// </summary>
public class BankAccountInfoResponse
{
    /// <summary>
    /// Transaction unique identifier (must match the request ID)
    /// </summary>
    public string TransactionId { get; set; } = string.Empty;
    
    /// <summary>
    /// Status information for the account info request
    /// </summary>
    public Status Status { get; set; } = new Status();
    
    /// <summary>
    /// Date and time of the response
    /// </summary>
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// List of bank accounts
    /// </summary>
    public List<BankAccountInfo> Accounts { get; set; } = new List<BankAccountInfo>();
}