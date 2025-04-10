using System;
using OFXSDK.Core.Enums;

namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Contains bank account information
/// </summary>
public class BankAccountInfo
{
    /// <summary>
    /// Gets or sets the account number
    /// </summary>
    public string AccountNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the account type
    /// </summary>
    public string AccountType { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the bank ID (routing number)
    /// </summary>
    public string BankId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the branch identifier
    /// </summary>
    public string BranchId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the account description or name
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the balance information
    /// </summary>
    public BalanceInfo Balance { get; set; } = new BalanceInfo();
}