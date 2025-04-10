using System;
using System.Collections.Generic;
using OFXSDK.Core.Models.SignOn;

namespace OFXSDK.Core.Models.Investment;

/// <summary>
/// Represents the investment response message set in an OFX document
/// </summary>
public class InvestmentResponseMessageSet
{
    /// <summary>
    /// Gets or sets the account information
    /// </summary>
    public InvestmentAccountInfo AccountInfo { get; set; } = new InvestmentAccountInfo();

    /// <summary>
    /// Gets or sets the statement response
    /// </summary>
    public InvestmentStatementResponse Statement { get; set; } = new InvestmentStatementResponse();
}