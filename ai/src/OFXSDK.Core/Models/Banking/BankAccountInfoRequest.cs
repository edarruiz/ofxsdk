using System;

namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Request for bank account information
/// </summary>
public class BankAccountInfoRequest
{
    /// <summary>
    /// Transaction unique identifier
    /// </summary>
    public string TransactionId { get; set; } = Guid.NewGuid().ToString();
}