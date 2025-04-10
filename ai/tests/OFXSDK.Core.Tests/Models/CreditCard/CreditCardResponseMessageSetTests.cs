using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.CreditCard;

namespace OFXSDK.Core.Tests.Models.CreditCard;

[TestClass]
public class CreditCardResponseMessageSetTests
{
    [TestMethod]
    public void CreditCardResponseMessageSet_DefaultValues_AreInitialized()
    {
        // Arrange
        var messageSet = new CreditCardResponseMessageSet();

        // Assert
        Assert.IsNotNull(messageSet.AccountInfo);
        Assert.IsNotNull(messageSet.Statement);
    }

    [TestMethod]
    public void CreditCardResponseMessageSet_CanSetAndGetProperties()
    {
        // Arrange
        var messageSet = new CreditCardResponseMessageSet();
        var accountInfo = new CreditCardAccountInfo { AccountNumber = "67890" };
        var statement = new CreditCardStatementResponse { CurrencyCode = "USD" };

        // Act
        messageSet.AccountInfo = accountInfo;
        messageSet.Statement = statement;

        // Assert
        Assert.AreEqual(accountInfo, messageSet.AccountInfo);
        Assert.AreEqual(statement, messageSet.Statement);
    }
}