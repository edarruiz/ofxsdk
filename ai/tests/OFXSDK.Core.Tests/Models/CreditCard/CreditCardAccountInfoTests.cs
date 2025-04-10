using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.CreditCard;

namespace OFXSDK.Core.Tests.Models.CreditCard;

[TestClass]
public class CreditCardAccountInfoTests
{
    [TestMethod]
    public void CreditCardAccountInfo_DefaultValues_AreInitialized()
    {
        // Arrange
        var accountInfo = new CreditCardAccountInfo();

        // Assert
        Assert.AreEqual(string.Empty, accountInfo.AccountNumber);
    }

    [TestMethod]
    public void CreditCardAccountInfo_CanSetAndGetProperties()
    {
        // Arrange
        var accountInfo = new CreditCardAccountInfo();
        var accountNumber = "67890";

        // Act
        accountInfo.AccountNumber = accountNumber;

        // Assert
        Assert.AreEqual(accountNumber, accountInfo.AccountNumber);
    }
}