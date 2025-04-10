using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.CreditCard;
using System;
using System.Collections.Generic;

namespace OFXSDK.Core.Tests.Models.CreditCard;

[TestClass]
public class CreditCardStatementResponseTests
{
    [TestMethod]
    public void CreditCardStatementResponse_DefaultValues_AreInitialized()
    {
        // Arrange
        var statementResponse = new CreditCardStatementResponse();

        // Assert
        Assert.IsNotNull(statementResponse.Balance);
        Assert.AreEqual("USD", statementResponse.CurrencyCode);
        Assert.AreEqual(default(DateTime), statementResponse.StartDate);
        Assert.AreEqual(default(DateTime), statementResponse.EndDate);
        Assert.IsNotNull(statementResponse.Transactions);
    }

    [TestMethod]
    public void CreditCardStatementResponse_CanSetAndGetProperties()
    {
        // Arrange
        var statementResponse = new CreditCardStatementResponse();
        var balance = new CreditCardBalanceInfo { AvailableCredit = 1000 };
        var currencyCode = "EUR";
        var startDate = DateTime.Now.AddDays(-30);
        var endDate = DateTime.Now;
        var transactions = new List<OFXSDK.Core.Models.Banking.Transaction> { new OFXSDK.Core.Models.Banking.Transaction { Amount = 100 } };

        // Act
        statementResponse.Balance = balance;
        statementResponse.CurrencyCode = currencyCode;
        statementResponse.StartDate = startDate;
        statementResponse.EndDate = endDate;
        statementResponse.Transactions = transactions;

        // Assert
        Assert.AreEqual(balance, statementResponse.Balance);
        Assert.AreEqual(currencyCode, statementResponse.CurrencyCode);
        Assert.AreEqual(startDate, statementResponse.StartDate);
        Assert.AreEqual(endDate, statementResponse.EndDate);
        Assert.AreEqual(transactions, statementResponse.Transactions);
    }
}