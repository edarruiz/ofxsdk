namespace OFXSDK.Core.Enums;

/// <summary>
/// Represents investment transaction types
/// </summary>
public enum InvestmentTransactionType
{
    /// <summary>
    /// Buy security
    /// </summary>
    BUY,
    
    /// <summary>
    /// Sell security
    /// </summary>
    SELL,
    
    /// <summary>
    /// Buy to cover a short position
    /// </summary>
    BUYTOCOVER,
    
    /// <summary>
    /// Sell short
    /// </summary>
    SELLSHORT,
    
    /// <summary>
    /// Dividend
    /// </summary>
    DIV,
    
    /// <summary>
    /// Interest earned
    /// </summary>
    INT,
    
    /// <summary>
    /// Margin interest
    /// </summary>
    MARGININT,
    
    /// <summary>
    /// Reinvest
    /// </summary>
    REINVEST,
    
    /// <summary>
    /// Split
    /// </summary>
    SPLIT,
    
    /// <summary>
    /// Transfer
    /// </summary>
    TRANSFER,
    
    /// <summary>
    /// Other investment transaction type
    /// </summary>
    OTHER
}

/// <summary>
/// Represents security types
/// </summary>
public enum SecurityType
{
    /// <summary>
    /// Stock
    /// </summary>
    STOCK,
    
    /// <summary>
    /// Bond
    /// </summary>
    BOND,
    
    /// <summary>
    /// Mutual fund
    /// </summary>
    MUFUND,
    
    /// <summary>
    /// Option
    /// </summary>
    OPTION,
    
    /// <summary>
    /// Exchange traded fund
    /// </summary>
    ETF,
    
    /// <summary>
    /// Index
    /// </summary>
    INDEX,
    
    /// <summary>
    /// Money market fund
    /// </summary>
    MMFUND,
    
    /// <summary>
    /// Other security type
    /// </summary>
    OTHER
}