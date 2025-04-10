namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Represents a bank statement response
/// </summary>
public class StatementResponse {
    /// <summary>
    /// Gets or sets the status of the statement response
    /// </summary>
    public Status Status { get; set; } = new Status();

    /// <summary>
    /// Gets or sets the currency code for the statement
    /// </summary>
    public string CurrencyCode { get; set; } = "USD";

    /// <summary>
    /// Gets or sets the start date of the statement
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date of the statement
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the collection of transactions
    /// </summary>
    public List<Transaction> Transactions { get; set; } = [];

    /// <summary>
    /// Gets or sets the balance information
    /// </summary>
    public BalanceInfo Balance { get; set; } = new BalanceInfo();
}