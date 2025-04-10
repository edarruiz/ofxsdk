using OFXSDK.Core.Models.CreditCard;

namespace OFXSDK.Core.Models;

/// <summary>
/// Represents credit card message sets for statements and other credit card operations
/// </summary>
public class CreditCardMessageSet {
    /// <summary>
    /// Credit card statement requests
    /// </summary>
    public List<CreditCardStatementRequest>? StatementRequests { get; set; }

    /// <summary>
    /// Credit card statement responses
    /// </summary>
    public List<CreditCardStatementResponse>? StatementResponses { get; set; }
}