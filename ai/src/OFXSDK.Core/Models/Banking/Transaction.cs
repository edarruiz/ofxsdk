using System;

namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Represents a bank transaction record
/// </summary>
public class Transaction
{
    /// <summary>
    /// Gets or sets the transaction ID
    /// </summary>
    public string TransactionId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the reference number
    /// </summary>
    public string ReferenceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the transaction type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date posted
    /// </summary>
    public DateTime DatePosted { get; set; }

    /// <summary>
    /// Gets or sets the transaction date
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Gets or sets the transaction amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the transaction name/description
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the memo or note associated with the transaction
    /// </summary>
    public string Memo { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the check number, if applicable
    /// </summary>
    public string CheckNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the payee information
    /// </summary>
    public string Payee { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the standard industrial code
    /// </summary>
    public string SIC { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets whether this is a corrected transaction
    /// </summary>
    public bool IsCorrected { get; set; }
}