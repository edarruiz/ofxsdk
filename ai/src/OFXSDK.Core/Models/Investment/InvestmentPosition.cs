using System;

namespace OFXSDK.Core.Models.Investment;

/// <summary>
/// Represents investment position information
/// </summary>
public class InvestmentPosition
{
    /// <summary>
    /// Gets or sets the security ID
    /// </summary>
    public SecurityInfo Security { get; set; } = new SecurityInfo();

    /// <summary>
    /// Gets or sets the position type (SHORT, LONG)
    /// </summary>
    public string PositionType { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the number of units held
    /// </summary>
    public decimal Units { get; set; }

    /// <summary>
    /// Gets or sets the unit price
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the market value of the position
    /// </summary>
    public decimal MarketValue { get; set; }

    /// <summary>
    /// Gets or sets the date of the position information
    /// </summary>
    public DateTime PositionDate { get; set; }
    
    /// <summary>
    /// Gets or sets the purchase price per unit
    /// </summary>
    public decimal PurchasePrice { get; set; }
    
    /// <summary>
    /// Gets or sets the date when the position was purchased
    /// </summary>
    public DateTime? PurchaseDate { get; set; }
    
    /// <summary>
    /// Gets or sets the memo or note associated with the position
    /// </summary>
    public string Memo { get; set; } = string.Empty;
}