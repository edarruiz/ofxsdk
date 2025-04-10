using System;

namespace OFXSDK.Core.Models.SignOn;

/// <summary>
/// Represents the sign-on response message set in an OFX document
/// </summary>
public class SignOnResponseMessageSet
{
    /// <summary>
    /// Gets or sets the status information for this message set
    /// </summary>
    public Status Status { get; set; } = new Status();

    /// <summary>
    /// Gets or sets the date and time of the server when generating this response
    /// </summary>
    public DateTime ServerDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the language used in the response
    /// </summary>
    public string Language { get; set; } = "ENG";

    /// <summary>
    /// Gets or sets the name of the financial institution
    /// </summary>
    public string InstitutionName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ID of the financial institution
    /// </summary>
    public string InstitutionId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets information about the message
    /// </summary>
    public string Message { get; set; } = string.Empty;
}