using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models;
using OFXSDK.Core.Models.Banking;
using OFXSDK.Core.Models.CreditCard;
using OFXSDK.Core.Models.Investment;
using OFXSDK.Core.Models.SignOn;

namespace OFXSDK.Core.Tests.Models;

[TestClass]
public class OFXDocumentTests
{
    [TestMethod]
    public void OFXDocument_DefaultValues_AreInitialized()
    {
        // Arrange
        var document = new OFXDocument();

        // Assert
        Assert.IsNotNull(document.Header);
        Assert.IsNotNull(document.SignOn);
        Assert.IsNull(document.Banking);
        Assert.IsNull(document.CreditCard);
        Assert.IsNull(document.Investment);
        Assert.AreNotEqual(default(DateTime), document.ParsedAt);
    }

    [TestMethod]
    public void OFXDocument_CanSetAndGetProperties()
    {
        // Arrange
        var document = new OFXDocument();
        var header = new OFXHeader { Version = "2.0" };
        var signOn = new SignOnResponseMessageSet { Language = "ENG" };
        var banking = new BankingResponseMessageSet { AccountInfo = new BankAccountInfo { AccountNumber = "12345" } };
        var creditCard = new CreditCardResponseMessageSet { AccountInfo = new CreditCardAccountInfo { AccountNumber = "67890" } };
        var investment = new InvestmentResponseMessageSet { AccountInfo = new InvestmentAccountInfo { AccountNumber = "13579" } };
        var parsedAt = DateTime.Now.AddDays(-1);

        // Act
        document.Header = header;
        document.SignOn = signOn;
        document.Banking = banking;
        document.CreditCard = creditCard;
        document.Investment = investment;
        document.ParsedAt = parsedAt;

        // Assert
        Assert.AreEqual(header, document.Header);
        Assert.AreEqual(signOn, document.SignOn);
        Assert.AreEqual(banking, document.Banking);
        Assert.AreEqual(creditCard, document.CreditCard);
        Assert.AreEqual(investment, document.Investment);
        Assert.AreEqual(parsedAt, document.ParsedAt);
    }
}