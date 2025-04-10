using System;
using System.Collections.Generic;
using OFXSDK.Core.Models.SignOn;

namespace OFXSDK.Core.Models.Investment;

/// <summary>
/// Represents an investment statement response
/// </summary>
public class InvestmentStatementResponse
{
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
    /// Gets or sets the collection of positions
    /// </summary>
    public List<InvestmentPosition> Positions { get; set; } = new List<InvestmentPosition>();

    /// <summary>
    /// Gets or sets the collection of transactions
    /// </summary>
    public List<InvestmentTransaction> Transactions { get; set; } = new List<InvestmentTransaction>();

    /// <summary>
    /// Gets or sets the balance information
    /// </summary>
    public InvestmentBalanceInfo BalanceInfo { get; set; } = new InvestmentBalanceInfo();

    /// <summary>
    /// Gets or sets the date as of which the positions are valid
    /// </summary>
    public DateTime PositionDate { get; set; }

    /// <summary>
    /// Gets or sets the market value of all positions
    /// </summary>
    public decimal TotalMarketValue { get; set; }
}