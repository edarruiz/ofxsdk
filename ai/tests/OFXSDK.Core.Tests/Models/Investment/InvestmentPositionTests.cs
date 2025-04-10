using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Investment;
using System;

namespace OFXSDK.Core.Tests.Models.Investment;

[TestClass]
public class InvestmentPositionTests
{
    [TestMethod]
    public void InvestmentPosition_DefaultValues_AreInitialized()
    {
        // Arrange
        var position = new InvestmentPosition();

        // Assert
        Assert.IsNotNull(position.Security);
        Assert.AreEqual(string.Empty, position.PositionType);
        Assert.AreEqual(0, position.Units);
        Assert.AreEqual(0, position.UnitPrice);
        Assert.AreEqual(0, position.MarketValue);
        Assert.AreEqual(default(DateTime), position.PositionDate);
    }

    [TestMethod]
    public void InvestmentPosition_CanSetAndGetProperties()
    {
        // Arrange
        var position = new InvestmentPosition();
        var security = new SecurityInfo { UniqueId = "XYZ" };
        var positionType = "LONG";
        var units = 100.00m;
        var unitPrice = 50.00m;
        var marketValue = 5000.00m;
        var positionDate = DateTime.Now;

        // Act
        position.Security = security;
        position.PositionType = positionType;
        position.Units = units;
        position.UnitPrice = unitPrice;
        position.MarketValue = marketValue;
        position.PositionDate = positionDate;

        // Assert
        Assert.AreEqual(security, position.Security);
        Assert.AreEqual(positionType, position.PositionType);
        Assert.AreEqual(units, position.Units);
        Assert.AreEqual(unitPrice, position.UnitPrice);
        Assert.AreEqual(marketValue, position.MarketValue);
        Assert.AreEqual(positionDate, position.PositionDate);
    }
}