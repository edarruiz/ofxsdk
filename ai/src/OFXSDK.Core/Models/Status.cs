using System;

namespace OFXSDK.Core.Models;

/// <summary>
/// Represents the status of an OFX request or response
/// </summary>
public class Status
{
    /// <summary>
    /// Status code (0 = success, non-zero = error)
    /// </summary>
    public int Code { get; set; }
    
    /// <summary>
    /// Severity of the status (INFO, WARN, ERROR)
    /// </summary>
    public string Severity { get; set; } = "INFO";
    
    /// <summary>
    /// Message describing the status
    /// </summary>
    public string Message { get; set; } = string.Empty;
    
    /// <summary>
    /// Determines if the status represents a success
    /// </summary>
    public bool IsSuccess => Code == 0;
}