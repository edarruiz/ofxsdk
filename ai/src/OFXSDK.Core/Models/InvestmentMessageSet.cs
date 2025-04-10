using System;
using System.Collections.Generic;
using OFXSDK.Core.Models.Investment;

namespace OFXSDK.Core.Models;

/// <summary>
/// Represents investment message sets for statements and other investment operations
/// </summary>
public class InvestmentMessageSet
{
    /// <summary>
    /// Investment statement requests
    /// </summary>
    public List<InvestmentStatementRequest>? StatementRequests { get; set; }
    
    /// <summary>
    /// Investment statement responses
    /// </summary>
    public List<InvestmentStatementResponse>? StatementResponses { get; set; }
}