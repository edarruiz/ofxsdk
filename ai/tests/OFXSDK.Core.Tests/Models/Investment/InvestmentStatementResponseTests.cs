using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Investment;
using System;
using System.Collections.Generic;

namespace OFXSDK.Core.Tests.Models.Investment;

[TestClass]
public class InvestmentStatementResponseTests
{
    [TestMethod]
    public void InvestmentStatementResponse_DefaultValues_AreInitialized()
    {
        // Arrange
        var statementResponse = new InvestmentStatementResponse();

        // Assert
        Assert.AreEqual("USD", statementResponse.CurrencyCode);
        Assert.AreEqual(default(DateTime), statementResponse.StartDate);
        Assert.AreEqual(default(DateTime), statementResponse.EndDate);
        Assert.IsNotNull(statementResponse.Positions);
        Assert.IsNotNull(statementResponse.Transactions);
        Assert.IsNotNull(statementResponse.BalanceInfo);
    }

    [TestMethod]
    public void InvestmentStatementResponse_CanSetAndGetProperties()
    {
        // Arrange
        var statementResponse = new InvestmentStatementResponse();
        var currencyCode = "EUR";
        var startDate = DateTime.Now.AddDays(-30);
        var endDate = DateTime.Now;
        var positions = new List<InvestmentPosition> { new InvestmentPosition { Units = 100 } };
        var transactions = new List<InvestmentTransaction> { new InvestmentTransaction { Amount = 50 } };
        var balanceInfo = new InvestmentBalanceInfo { AvailableCash = 1000 };

        // Act
        statementResponse.CurrencyCode = currencyCode;
        statementResponse.StartDate = startDate;
        statementResponse.EndDate = endDate;
        statementResponse.Positions = positions;
        statementResponse.Transactions = transactions;
        statementResponse.BalanceInfo = balanceInfo;

        // Assert
        Assert.AreEqual(currencyCode, statementResponse.CurrencyCode);
        Assert.AreEqual(startDate, statementResponse.StartDate);
        Assert.AreEqual(endDate, statementResponse.EndDate);
        Assert.AreEqual(positions, statementResponse.Positions);
        Assert.AreEqual(transactions, statementResponse.Transactions);
        Assert.AreEqual(balanceInfo, statementResponse.BalanceInfo);
    }
}