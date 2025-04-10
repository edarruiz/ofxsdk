using OFXSDK.Core.Models.Banking;

namespace OFXSDK.Core.Models.CreditCard;

/// <summary>
/// Represents the credit card response message set in an OFX document
/// </summary>
public class CreditCardResponseMessageSet {
    /// <summary>
    /// Gets or sets the account information
    /// </summary>
    public CreditCardAccountInfo AccountInfo { get; set; } = new CreditCardAccountInfo();

    /// <summary>
    /// Gets or sets the statement response
    /// </summary>
    public CreditCardStatementResponse Statement { get; set; } = new CreditCardStatementResponse();
}

/// <summary>
/// Represents credit card account information
/// </summary>
public class CreditCardAccountInfo {
    /// <summary>
    /// Gets or sets the account number
    /// </summary>
    public string AccountNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the account description or name
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the credit card issuer ID
    /// </summary>
    public string IssuerId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the credit limit
    /// </summary>
    public decimal CreditLimit { get; set; }

    /// <summary>
    /// Gets or sets the balance information
    /// </summary>
    public CreditCardBalanceInfo Balance { get; set; } = new CreditCardBalanceInfo();
}

/// <summary>
/// Represents a credit card statement response
/// </summary>
public class CreditCardStatementResponse {
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
    public CreditCardBalanceInfo Balance { get; set; } = new CreditCardBalanceInfo();

    /// <summary>
    /// Gets or sets the payment due date
    /// </summary>
    public DateTime? PaymentDueDate { get; set; }

    /// <summary>
    /// Gets or sets the minimum payment due
    /// </summary>
    public decimal MinimumPaymentDue { get; set; }
}

/// <summary>
/// Represents credit card balance information
/// </summary>
public class CreditCardBalanceInfo {
    /// <summary>
    /// Gets or sets the current balance amount
    /// </summary>
    public decimal CurrentBalance { get; set; }

    /// <summary>
    /// Gets or sets the date of the current balance
    /// </summary>
    public DateTime CurrentBalanceDate { get; set; }

    /// <summary>
    /// Gets or sets the available credit
    /// </summary>
    public decimal AvailableCredit { get; set; }

    /// <summary>
    /// Gets or sets the date of the available credit
    /// </summary>
    public DateTime AvailableCreditDate { get; set; }
}