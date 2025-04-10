using System;

namespace OFXSDK.Core.Models.SignOn;

/// <summary>
/// Represents a sign-on response from a financial institution
/// </summary>
public class SignOnResponse
{
    /// <summary>
    /// Status information for the sign-on request
    /// </summary>
    public Status Status { get; set; } = new Status();
    
    /// <summary>
    /// Date and time of the server response
    /// </summary>
    public DateTime DtServer { get; set; }
    
    /// <summary>
    /// User ID that was used for authentication
    /// </summary>
    public string UserId { get; set; } = string.Empty;
    
    /// <summary>
    /// Language used for the response
    /// </summary>
    public string Language { get; set; } = "ENG";
    
    /// <summary>
    /// Financial institution ID
    /// </summary>
    public string FinancialInstitutionId { get; set; } = string.Empty;
    
    /// <summary>
    /// Session cookie for maintaining session state
    /// </summary>
    public string SessionCookie { get; set; } = string.Empty;
}