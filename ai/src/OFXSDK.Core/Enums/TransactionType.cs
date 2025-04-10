namespace OFXSDK.Core.Enums;

/// <summary>
/// Types of bank transactions
/// </summary>
public enum TransactionType
{
    /// <summary>
    /// Credit (money deposited into account)
    /// </summary>
    CREDIT,
    
    /// <summary>
    /// Debit (money withdrawn from account)
    /// </summary>
    DEBIT,
    
    /// <summary>
    /// Interest earned
    /// </summary>
    INT,
    
    /// <summary>
    /// Dividend payment
    /// </summary>
    DIV,
    
    /// <summary>
    /// Fee charged
    /// </summary>
    FEE,
    
    /// <summary>
    /// Service charge
    /// </summary>
    SRVCHG,
    
    /// <summary>
    /// Deposit
    /// </summary>
    DEP,
    
    /// <summary>
    /// ATM transaction
    /// </summary>
    ATM,
    
    /// <summary>
    /// Point of sale transaction
    /// </summary>
    POS,
    
    /// <summary>
    /// Transfer
    /// </summary>
    XFER,
    
    /// <summary>
    /// Check
    /// </summary>
    CHECK,
    
    /// <summary>
    /// Payment
    /// </summary>
    PAYMENT,
    
    /// <summary>
    /// Cash withdrawal
    /// </summary>
    CASH,
    
    /// <summary>
    /// Direct deposit
    /// </summary>
    DIRECTDEP,
    
    /// <summary>
    /// Direct debit
    /// </summary>
    DIRECTDEBIT,
    
    /// <summary>
    /// Repeating payment/standing order
    /// </summary>
    REPEATPMT,
    
    /// <summary>
    /// Other transaction type
    /// </summary>
    OTHER
}