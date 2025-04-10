using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Investment;

namespace OFXSDK.Core.Tests.Models.Investment;

[TestClass]
public class InvestmentAccountInfoTests
{
    [TestMethod]
    public void InvestmentAccountInfo_DefaultValues_AreInitialized()
    {
        // Arrange
        var accountInfo = new InvestmentAccountInfo();

        // Assert
        Assert.AreEqual(string.Empty, accountInfo.AccountNumber);
        Assert.AreEqual(string.Empty, accountInfo.BrokerId);
    }

    [TestMethod]
    public void InvestmentAccountInfo_CanSetAndGetProperties()
    {
        // Arrange
        var accountInfo = new InvestmentAccountInfo();
        var accountNumber = "12345";
        var brokerId = "98765";

        // Act
        accountInfo.AccountNumber = accountNumber;
        accountInfo.BrokerId = brokerId;

        // Assert
        Assert.AreEqual(accountNumber, accountInfo.AccountNumber);
        Assert.AreEqual(brokerId, accountInfo.BrokerId);
    }
}