using System.Threading.Tasks;
using OFXSDK.Core.Models;
using OFXSDK.Validation.Models;

namespace OFXSDK.Validation.Interfaces;

/// <summary>
/// Interface for OFX document validators
/// </summary>
public interface IOFXValidator
{
    /// <summary>
    /// Validates an OFX document
    /// </summary>
    /// <param name="document">OFX document to validate</param>
    /// <returns>Validation result</returns>
    ValidationResult Validate(OFXDocument document);

    /// <summary>
    /// Asynchronously validates an OFX document
    /// </summary>
    /// <param name="document">OFX document to validate</param>
    /// <returns>Task containing validation result</returns>
    Task<ValidationResult> ValidateAsync(OFXDocument document);
}