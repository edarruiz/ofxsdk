using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models;
using OFXSDK.Core.Models.Banking;

namespace OFXSDK.Core.Tests.Models.Banking;

[TestClass]
public class StatementResponseTests {
    [TestMethod]
    public void StatementResponse_DefaultValues_AreInitialized() {
        // Arrange
        var statementResponse = new StatementResponse();

        // Assert
        Assert.IsNotNull(statementResponse.Status);
        Assert.AreEqual("USD", statementResponse.CurrencyCode);
        Assert.AreEqual(default, statementResponse.StartDate);
        Assert.AreEqual(default, statementResponse.EndDate);
        Assert.IsNotNull(statementResponse.Transactions);
        Assert.IsNotNull(statementResponse.Balance);
    }

    [TestMethod]
    public void StatementResponse_CanSetAndGetProperties() {
        // Arrange
        var statementResponse = new StatementResponse();
        var status = new Status { Code = 0 };
        var currencyCode = "EUR";
        var startDate = DateTime.Now.AddDays(-30);
        var endDate = DateTime.Now;
        var transactions = new List<Transaction> { new() { Amount = 100 } };
        var balance = new BalanceInfo { LedgerBalance = 500 };

        // Act
        statementResponse.Status = status;
        statementResponse.CurrencyCode = currencyCode;
        statementResponse.StartDate = startDate;
        statementResponse.EndDate = endDate;
        statementResponse.Transactions = transactions;
        statementResponse.Balance = balance;

        // Assert
        Assert.AreEqual(status, statementResponse.Status);
        Assert.AreEqual(currencyCode, statementResponse.CurrencyCode);
        Assert.AreEqual(startDate, statementResponse.StartDate);
        Assert.AreEqual(endDate, statementResponse.EndDate);
        Assert.AreEqual(transactions, statementResponse.Transactions);
        Assert.AreEqual(balance, statementResponse.Balance);
    }
}