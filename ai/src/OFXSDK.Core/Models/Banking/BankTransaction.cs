using System;
using OFXSDK.Core.Enums;

namespace OFXSDK.Core.Models.Banking;

/// <summary>
/// Represents a bank transaction
/// </summary>
public class BankTransaction
{
    /// <summary>
    /// Transaction unique identifier
    /// </summary>
    public string TransactionId { get; set; } = string.Empty;
    
    /// <summary>
    /// Transaction type (CREDIT, DEBIT, etc.)
    /// </summary>
    public TransactionType Type { get; set; }
    
    /// <summary>
    /// Date the transaction was posted to the account
    /// </summary>
    public DateTime DatePosted { get; set; }
    
    /// <summary>
    /// Date the transaction occurred
    /// </summary>
    public DateTime? DateInitiated { get; set; }
    
    /// <summary>
    /// Transaction amount
    /// </summary>
    public decimal Amount { get; set; }
    
    /// <summary>
    /// Name of the entity involved in the transaction
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Memo or description of the transaction
    /// </summary>
    public string Memo { get; set; } = string.Empty;
    
    /// <summary>
    /// Check number if applicable
    /// </summary>
    public string? CheckNumber { get; set; }
    
    /// <summary>
    /// Reference number for the transaction
    /// </summary>
    public string? ReferenceNumber { get; set; }
}