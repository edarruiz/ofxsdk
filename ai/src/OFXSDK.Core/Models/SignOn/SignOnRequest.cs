using System;

namespace OFXSDK.Core.Models.SignOn;

/// <summary>
/// Represents a sign-on request to authenticate with a financial institution
/// </summary>
public class SignOnRequest
{
    /// <summary>
    /// Date and time of the request
    /// </summary>
    public DateTime DtClient { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// User ID for authentication
    /// </summary>
    public string UserId { get; set; } = string.Empty;
    
    /// <summary>
    /// User password for authentication
    /// </summary>
    public string Password { get; set; } = string.Empty;
    
    /// <summary>
    /// Financial institution ID
    /// </summary>
    public string FinancialInstitutionId { get; set; } = string.Empty;
    
    /// <summary>
    /// Application ID and version
    /// </summary>
    public string AppId { get; set; } = "OFXSDK";
    
    /// <summary>
    /// Application version
    /// </summary>
    public string AppVersion { get; set; } = "1.0";
    
    /// <summary>
    /// Client unique ID
    /// </summary>
    public string ClientUid { get; set; } = Guid.NewGuid().ToString();
}