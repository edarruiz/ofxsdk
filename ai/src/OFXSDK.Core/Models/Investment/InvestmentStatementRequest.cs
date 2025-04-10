using System;

namespace OFXSDK.Core.Models.Investment;

/// <summary>
/// Represents an investment statement request
/// </summary>
public class InvestmentStatementRequest
{
    /// <summary>
    /// Gets or sets the account information
    /// </summary>
    public InvestmentAccountInfo AccountInfo { get; set; } = new InvestmentAccountInfo();
    
    /// <summary>
    /// Gets or sets the start date for the requested statement
    /// </summary>
    public DateTime? StartDate { get; set; }
    
    /// <summary>
    /// Gets or sets the end date for the requested statement
    /// </summary>
    public DateTime? EndDate { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether to include transactions
    /// </summary>
    public bool IncludeTransactions { get; set; } = true;
    
    /// <summary>
    /// Gets or sets a value indicating whether to include positions
    /// </summary>
    public bool IncludePositions { get; set; } = true;
    
    /// <summary>
    /// Gets or sets a value indicating whether to include open orders
    /// </summary>
    public bool IncludeOpenOrders { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether to include balance information
    /// </summary>
    public bool IncludeBalances { get; set; } = true;
}