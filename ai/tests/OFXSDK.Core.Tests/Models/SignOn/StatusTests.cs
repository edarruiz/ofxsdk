using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models;

namespace OFXSDK.Core.Tests.Models.SignOn;

[TestClass]
public class StatusTests {
    [TestMethod]
    public void Status_DefaultValues_AreInitialized() {
        // Arrange
        var status = new Status();

        // Assert
        Assert.AreEqual("INFO", status.Severity);
        Assert.AreEqual(0, status.Code);
        Assert.AreEqual(string.Empty, status.Message);
    }

    [TestMethod]
    public void Status_CanSetAndGetProperties() {
        // Arrange
        var status = new Status();
        var severity = "ERROR";
        var code = 2000;
        var message = "Invalid account number";

        // Act
        status.Severity = severity;
        status.Code = code;
        status.Message = message;

        // Assert
        Assert.AreEqual(severity, status.Severity);
        Assert.AreEqual(code, status.Code);
        Assert.AreEqual(message, status.Message);
    }

    [TestMethod]
    public void Status_IsSuccess_ReturnsTrueForCodeZero() {
        // Arrange
        var status = new Status { Code = 0 };

        // Assert
        Assert.IsTrue(status.IsSuccess);
    }

    [TestMethod]
    public void Status_IsSuccess_ReturnsFalseForNonZeroCode() {
        // Arrange
        var status = new Status { Code = 2000 };

        // Assert
        Assert.IsFalse(status.IsSuccess);
    }
}