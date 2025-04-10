using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Banking;
using System;

namespace OFXSDK.Core.Tests.Models.Banking;

[TestClass]
public class TransactionTests
{
    [TestMethod]
    public void Transaction_DefaultValues_AreInitialized()
    {
        // Arrange
        var transaction = new Transaction();

        // Assert
        Assert.AreEqual(string.Empty, transaction.TransactionId);
        Assert.AreEqual(string.Empty, transaction.Type);
        Assert.AreEqual(default(DateTime), transaction.DatePosted);
        Assert.AreEqual(0, transaction.Amount);
    }

    [TestMethod]
    public void Transaction_CanSetAndGetProperties()
    {
        // Arrange
        var transaction = new Transaction();
        var transactionId = "12345";
        var type = "CREDIT";
        var datePosted = DateTime.Now;
        var amount = 100.00m;

        // Act
        transaction.TransactionId = transactionId;
        transaction.Type = type;
        transaction.DatePosted = datePosted;
        transaction.Amount = amount;

        // Assert
        Assert.AreEqual(transactionId, transaction.TransactionId);
        Assert.AreEqual(type, transaction.Type);
        Assert.AreEqual(datePosted, transaction.DatePosted);
        Assert.AreEqual(amount, transaction.Amount);
    }
}