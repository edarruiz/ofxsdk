namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Represents the banking response message set in an OFX document
/// </summary>
public class BankingResponseMessageSet
{
    /// <summary>
    /// Gets or sets the account information
    /// </summary>
    public BankAccountInfo AccountInfo { get; set; } = new BankAccountInfo();

    /// <summary>
    /// Gets or sets the statement response
    /// </summary>
    public StatementResponse Statement { get; set; } = new StatementResponse();
}