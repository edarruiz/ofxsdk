using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Investment;

namespace OFXSDK.Core.Tests.Models.Investment;

[TestClass]
public class InvestmentResponseMessageSetTests
{
    [TestMethod]
    public void InvestmentResponseMessageSet_DefaultValues_AreInitialized()
    {
        // Arrange
        var messageSet = new InvestmentResponseMessageSet();

        // Assert
        Assert.IsNotNull(messageSet.AccountInfo);
        Assert.IsNotNull(messageSet.Statement);
    }

    [TestMethod]
    public void InvestmentResponseMessageSet_CanSetAndGetProperties()
    {
        // Arrange
        var messageSet = new InvestmentResponseMessageSet();
        var accountInfo = new InvestmentAccountInfo { AccountNumber = "12345" };
        var statement = new InvestmentStatementResponse { CurrencyCode = "USD" };

        // Act
        messageSet.AccountInfo = accountInfo;
        messageSet.Statement = statement;

        // Assert
        Assert.AreEqual(accountInfo, messageSet.AccountInfo);
        Assert.AreEqual(statement, messageSet.Statement);
    }
}