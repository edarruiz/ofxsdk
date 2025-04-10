using OFXSDK.Core.Models.Banking;
using OFXSDK.Core.Models.CreditCard;
using OFXSDK.Core.Models.SignOn;

namespace OFXSDK.Core.Models;

/// <summary>
/// Represents a complete OFX document with all its elements
/// </summary>
public class OFXDocument {
    /// <summary>
    /// Gets or sets the OFX header information
    /// </summary>
    public OFXHeader Header { get; set; } = new OFXHeader();

    /// <summary>
    /// Gets or sets the sign-on response message set
    /// </summary>
    public SignOnResponseMessageSet SignOn { get; set; } = new SignOnResponseMessageSet();

    /// <summary>
    /// Gets or sets the banking response message set
    /// </summary>
    public BankingResponseMessageSet? Banking { get; set; }

    /// <summary>
    /// Gets or sets the credit card response message set
    /// </summary>
    public CreditCardResponseMessageSet? CreditCard { get; set; }

    /// <summary>
    /// Gets or sets the investment response message set
    /// </summary>
    public Investment.InvestmentResponseMessageSet? Investment { get; set; } // Explicitly specify the namespace

    /// <summary>
    /// Gets or sets the timestamp when this document was parsed
    /// </summary>
    public DateTime ParsedAt { get; set; } = DateTime.Now;
}