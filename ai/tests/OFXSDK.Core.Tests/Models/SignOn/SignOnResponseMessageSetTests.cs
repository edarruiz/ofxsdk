using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models;
using OFXSDK.Core.Models.SignOn;

namespace OFXSDK.Core.Tests.Models.SignOn;

[TestClass]
public class SignOnResponseMessageSetTests {
    [TestMethod]
    public void SignOnResponseMessageSet_DefaultValues_AreInitialized() {
        // Arrange
        var messageSet = new SignOnResponseMessageSet();

        // Assert
        Assert.IsNotNull(messageSet.Status);
        Assert.AreNotEqual(default(DateTime), messageSet.ServerDate);
        Assert.AreEqual("ENG", messageSet.Language);
        Assert.AreEqual(string.Empty, messageSet.InstitutionName);
        Assert.AreEqual(string.Empty, messageSet.InstitutionId);
    }

    [TestMethod]
    public void SignOnResponseMessageSet_CanSetAndGetProperties() {
        // Arrange
        var messageSet = new SignOnResponseMessageSet();
        var status = new Status { Code = 0 };
        var serverDate = DateTime.Now;
        var language = "FRE";
        var institutionName = "Bank of America";
        var institutionId = "12345";

        // Act
        messageSet.Status = status;
        messageSet.ServerDate = serverDate;
        messageSet.Language = language;
        messageSet.InstitutionName = institutionName;
        messageSet.InstitutionId = institutionId;

        // Assert
        Assert.AreEqual(status, messageSet.Status);
        Assert.AreEqual(serverDate, messageSet.ServerDate);
        Assert.AreEqual(language, messageSet.Language);
        Assert.AreEqual(institutionName, messageSet.InstitutionName);
        Assert.AreEqual(institutionId, messageSet.InstitutionId);
    }
}