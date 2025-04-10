using System;
using System.Collections.Generic;
using OFXSDK.Core.Models.Banking;

namespace OFXSDK.Core.Models;

/// <summary>
/// Represents banking message sets for statements, transfers, and other banking operations
/// </summary>
public class BankingMessageSet
{
    /// <summary>
    /// Banking statement requests
    /// </summary>
    public List<BankStatementRequest>? StatementRequests { get; set; }
    
    /// <summary>
    /// Banking statement responses
    /// </summary>
    public List<BankStatementResponse>? StatementResponses { get; set; }
    
    /// <summary>
    /// Bank account information requests
    /// </summary>
    public List<BankAccountInfoRequest>? AccountInfoRequests { get; set; }
    
    /// <summary>
    /// Bank account information responses
    /// </summary>
    public List<BankAccountInfoResponse>? AccountInfoResponses { get; set; }
}