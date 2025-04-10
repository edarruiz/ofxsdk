using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Banking;

namespace OFXSDK.Core.Tests.Models.Banking;

[TestClass]
public class BalanceInfoTests {
    [TestMethod]
    public void BalanceInfo_DefaultValues_AreInitialized() {
        // Arrange
        var balanceInfo = new BalanceInfo();

        // Assert
        Assert.AreEqual(0, balanceInfo.LedgerBalance);
        Assert.AreEqual(default(DateTime), balanceInfo.LedgerBalanceDate);
        Assert.AreEqual(0, balanceInfo.AvailableBalance);
        Assert.AreEqual(default(DateTime), balanceInfo.AvailableBalanceDate);
    }

    [TestMethod]
    public void BalanceInfo_CanSetAndGetProperties() {
        // Arrange
        var balanceInfo = new BalanceInfo();
        var ledgerBalance = 100.00m;
        var ledgerBalanceDate = DateTime.Now.AddDays(-1);
        var availableBalance = 50.00m;
        var availableBalanceDate = DateTime.Now;

        // Act
        balanceInfo.LedgerBalance = ledgerBalance;
        balanceInfo.LedgerBalanceDate = ledgerBalanceDate;
        balanceInfo.AvailableBalance = availableBalance;
        balanceInfo.AvailableBalanceDate = availableBalanceDate;

        // Assert
        Assert.AreEqual(ledgerBalance, balanceInfo.LedgerBalance);
        Assert.AreEqual(ledgerBalanceDate, balanceInfo.LedgerBalanceDate);
        Assert.AreEqual(availableBalance, balanceInfo.AvailableBalance);
        Assert.AreEqual(availableBalanceDate, balanceInfo.AvailableBalanceDate);
    }
}