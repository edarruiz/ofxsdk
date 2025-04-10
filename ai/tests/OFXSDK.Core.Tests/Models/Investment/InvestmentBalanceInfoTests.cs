using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Investment;
using System;

namespace OFXSDK.Core.Tests.Models.Investment;

[TestClass]
public class InvestmentBalanceInfoTests
{
    [TestMethod]
    public void InvestmentBalanceInfo_DefaultValues_AreInitialized()
    {
        // Arrange
        var balanceInfo = new InvestmentBalanceInfo();

        // Assert
        Assert.AreEqual(0, balanceInfo.AvailableCash);
        Assert.AreEqual(0, balanceInfo.MarginBalance);
        Assert.AreEqual(0, balanceInfo.ShortBalance);
        Assert.AreEqual(default(DateTime), balanceInfo.BalanceDate);
    }

    [TestMethod]
    public void InvestmentBalanceInfo_CanSetAndGetProperties()
    {
        // Arrange
        var balanceInfo = new InvestmentBalanceInfo();
        var availableCash = 1000.00m;
        var marginBalance = 500.00m;
        var shortBalance = 100.00m;
        var balanceDate = DateTime.Now;

        // Act
        balanceInfo.AvailableCash = availableCash;
        balanceInfo.MarginBalance = marginBalance;
        balanceInfo.ShortBalance = shortBalance;
        balanceInfo.BalanceDate = balanceDate;

        // Assert
        Assert.AreEqual(availableCash, balanceInfo.AvailableCash);
        Assert.AreEqual(marginBalance, balanceInfo.MarginBalance);
        Assert.AreEqual(shortBalance, balanceInfo.ShortBalance);
        Assert.AreEqual(balanceDate, balanceInfo.BalanceDate);
    }
}