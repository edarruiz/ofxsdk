using System.Collections.Generic;
using System.Linq;

namespace OFXSDK.Validation.Models;

/// <summary>
/// Represents the result of a validation operation
/// </summary>
public class ValidationResult
{
    /// <summary>
    /// Gets a value indicating whether the validation was successful
    /// </summary>
    public bool IsValid => !Errors.Any();

    /// <summary>
    /// Gets the collection of validation errors
    /// </summary>
    public List<string> Errors { get; } = new List<string>();

    /// <summary>
    /// Gets the combined error message from all errors
    /// </summary>
    public string ErrorMessage => string.Join("; ", Errors);

    /// <summary>
    /// Adds an error to the validation result
    /// </summary>
    /// <param name="errorMessage">Error message to add</param>
    public void AddError(string errorMessage)
    {
        if (!string.IsNullOrWhiteSpace(errorMessage))
        {
            Errors.Add(errorMessage);
        }
    }

    /// <summary>
    /// Creates a successful validation result
    /// </summary>
    public static ValidationResult Success() => new ValidationResult();

    /// <summary>
    /// Creates a failed validation result with the specified error message
    /// </summary>
    /// <param name="errorMessage">Error message</param>
    public static ValidationResult Failure(string errorMessage)
    {
        var result = new ValidationResult();
        result.AddError(errorMessage);
        return result;
    }

    /// <summary>
    /// Creates a failed validation result with the specified collection of error messages
    /// </summary>
    /// <param name="errorMessages">Collection of error messages</param>
    public static ValidationResult Failure(IEnumerable<string> errorMessages)
    {
        var result = new ValidationResult();
        foreach (var error in errorMessages)
        {
            result.AddError(error);
        }
        return result;
    }
}