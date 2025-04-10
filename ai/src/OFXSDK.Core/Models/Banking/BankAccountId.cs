namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Identifies a specific bank account
/// </summary>
public class BankAccountId
{
    /// <summary>
    /// Account number
    /// </summary>
    public string AccountNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// Account type
    /// </summary>
    public string AccountType { get; set; } = string.Empty;
    
    /// <summary>
    /// Bank identifier code
    /// </summary>
    public string BankId { get; set; } = string.Empty;
    
    /// <summary>
    /// Branch identifier
    /// </summary>
    public string BranchId { get; set; } = string.Empty;
}