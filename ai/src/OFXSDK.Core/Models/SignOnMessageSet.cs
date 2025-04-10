using System;
using OFXSDK.Core.Models.SignOn;

namespace OFXSDK.Core.Models;

/// <summary>
/// Represents the sign-on message set required for OFX authentication
/// </summary>
public class SignOnMessageSet
{
    /// <summary>
    /// Sign-on request information for client authentication
    /// </summary>
    public SignOnRequest? Request { get; set; }
    
    /// <summary>
    /// Sign-on response information from the financial institution
    /// </summary>
    public SignOnResponse? Response { get; set; }
}