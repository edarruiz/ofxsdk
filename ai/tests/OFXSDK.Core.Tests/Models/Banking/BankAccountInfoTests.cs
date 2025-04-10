using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Banking;

namespace OFXSDK.Core.Tests.Models.Banking;

[TestClass]
public class BankAccountInfoTests
{
    [TestMethod]
    public void BankAccountInfo_DefaultValues_AreInitialized()
    {
        // Arrange
        var accountInfo = new BankAccountInfo();

        // Assert
        Assert.AreEqual(string.Empty, accountInfo.AccountNumber);
        Assert.AreEqual(string.Empty, accountInfo.AccountType);
        Assert.AreEqual(string.Empty, accountInfo.BankId);
    }

    [TestMethod]
    public void BankAccountInfo_CanSetAndGetProperties()
    {
        // Arrange
        var accountInfo = new BankAccountInfo();
        var accountNumber = "12345";
        var accountType = "Checking";
        var bankId = "98765";

        // Act
        accountInfo.AccountNumber = accountNumber;
        accountInfo.AccountType = accountType;
        accountInfo.BankId = bankId;

        // Assert
        Assert.AreEqual(accountNumber, accountInfo.AccountNumber);
        Assert.AreEqual(accountType, accountInfo.AccountType);
        Assert.AreEqual(bankId, accountInfo.BankId);
    }
}