using OFXSDK.Core.Models;
using OFXSDK.Core.Models.Banking;
using OFXSDK.Core.Models.CreditCard;
using OFXSDK.Validation.Interfaces;
using OFXSDK.Validation.Models;

namespace OFXSDK.Validation.Validators;

/// <summary>
/// Provides basic validation for OFX documents
/// </summary>
public class BasicOFXValidator : IOFXValidator {
    /// <summary>
    /// Validates an OFX document
    /// </summary>
    public ValidationResult Validate(OFXDocument document) {
        if (document == null) {
            return ValidationResult.Failure("OFX document cannot be null");
        }

        var result = new ValidationResult();

        // Check header values
        if (string.IsNullOrWhiteSpace(document.Header?.Version)) {
            result.AddError("OFX header version is required");
        }

        // Check for sign-on message set
        if (document.SignOn == null) {
            result.AddError("Sign-on message set is required");
        } else {
            // Check sign-on status
            if (document.SignOn.Status == null) {
                result.AddError("Sign-on status is required");
            } else if (!document.SignOn.Status.IsSuccess) {
                result.AddError($"Sign-on has an error (Code: {document.SignOn.Status.Code}, Message: {document.SignOn.Status.Message})");
            }
        }

        // Basic validation for banking message set
        if (document.Banking != null) {
            ValidateBankingMessageSet(document.Banking, result);
        }

        // Basic validation for credit card message set
        if (document.CreditCard != null) {
            ValidateCreditCardMessageSet(document.CreditCard, result);
        }

        return result;
    }

    /// <summary>
    /// Asynchronously validates an OFX document
    /// </summary>
    public Task<ValidationResult> ValidateAsync(OFXDocument document) {
        // Since validation is CPU-bound and doesn't involve I/O,
        // we can simply wrap the synchronous method in a Task
        return Task.FromResult(Validate(document));
    }

    /// <summary>
    /// Validates the banking message set
    /// </summary>
    private static void ValidateBankingMessageSet(BankingResponseMessageSet banking, ValidationResult result) {
        if (banking.AccountInfo == null) {
            result.AddError("Banking account information is required");
        } else {
            if (string.IsNullOrWhiteSpace(banking.AccountInfo.AccountNumber)) {
                result.AddError("Banking account number is required");
            }
        }

        if (banking.Statement == null) {
            result.AddError("Banking statement is required");
        } else {
            if (banking.Statement.Status != null && !banking.Statement.Status.IsSuccess) {
                result.AddError($"Banking statement has an error (Code: {banking.Statement.Status.Code}, Message: {banking.Statement.Status.Message})");
            }
        }
    }

    /// <summary>
    /// Validates the credit card message set
    /// </summary>
    private static void ValidateCreditCardMessageSet(CreditCardResponseMessageSet creditCard, ValidationResult result) {
        if (creditCard.AccountInfo == null) {
            result.AddError("Credit card account information is required");
        } else {
            if (string.IsNullOrWhiteSpace(creditCard.AccountInfo.AccountNumber)) {
                result.AddError("Credit card account number is required");
            }
        }

        if (creditCard.Statement == null) {
            result.AddError("Credit card statement is required");
        } else {
            if (creditCard.Statement.Status != null && !creditCard.Statement.Status.IsSuccess) {
                result.AddError($"Credit card statement has an error (Code: {creditCard.Statement.Status.Code}, Message: {creditCard.Statement.Status.Message})");
            }
        }
    }
}