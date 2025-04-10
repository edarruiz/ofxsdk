using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Investment;
using System;

namespace OFXSDK.Core.Tests.Models.Investment;

[TestClass]
public class InvestmentTransactionTests
{
    [TestMethod]
    public void InvestmentTransaction_DefaultValues_AreInitialized()
    {
        // Arrange
        var transaction = new InvestmentTransaction();

        // Assert
        Assert.AreEqual(string.Empty, transaction.TransactionId);
        Assert.AreEqual(string.Empty, transaction.TransactionType);
        Assert.AreEqual(default(DateTime), transaction.DatePosted);
        Assert.AreEqual(0, transaction.Amount);
        Assert.IsNull(transaction.Security);
    }

    [TestMethod]
    public void InvestmentTransaction_CanSetAndGetProperties()
    {
        // Arrange
        var transaction = new InvestmentTransaction();
        var transactionId = "12345";
        var transactionType = "BUY";
        var datePosted = DateTime.Now;
        var amount = 100.00m;
        var security = new SecurityInfo { UniqueId = "XYZ" };

        // Act
        transaction.TransactionId = transactionId;
        transaction.TransactionType = transactionType;
        transaction.DatePosted = datePosted;
        transaction.Amount = amount;
        transaction.Security = security;

        // Assert
        Assert.AreEqual(transactionId, transaction.TransactionId);
        Assert.AreEqual(transactionType, transaction.TransactionType);
        Assert.AreEqual(datePosted, transaction.DatePosted);
        Assert.AreEqual(amount, transaction.Amount);
        Assert.AreEqual(security, transaction.Security);
    }
}