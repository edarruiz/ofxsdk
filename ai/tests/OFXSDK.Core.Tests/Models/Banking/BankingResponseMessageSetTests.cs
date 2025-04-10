using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Banking;

namespace OFXSDK.Core.Tests.Models.Banking;

[TestClass]
public class BankingResponseMessageSetTests
{
    [TestMethod]
    public void BankingResponseMessageSet_DefaultValues_AreInitialized()
    {
        // Arrange
        var messageSet = new BankingResponseMessageSet();

        // Assert
        Assert.IsNotNull(messageSet.AccountInfo);
        Assert.IsNotNull(messageSet.Statement);
    }

    [TestMethod]
    public void BankingResponseMessageSet_CanSetAndGetProperties()
    {
        // Arrange
        var messageSet = new BankingResponseMessageSet();
        var accountInfo = new BankAccountInfo { AccountNumber = "12345" };
        var statement = new StatementResponse { CurrencyCode = "USD" };

        // Act
        messageSet.AccountInfo = accountInfo;
        messageSet.Statement = statement;

        // Assert
        Assert.AreEqual(accountInfo, messageSet.AccountInfo);
        Assert.AreEqual(statement, messageSet.Statement);
    }
}