using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Core.Models.Investment;

namespace OFXSDK.Core.Tests.Models.Investment;

[TestClass]
public class SecurityInfoTests
{
    [TestMethod]
    public void SecurityInfo_DefaultValues_AreInitialized()
    {
        // Arrange
        var securityInfo = new SecurityInfo();

        // Assert
        Assert.AreEqual(string.Empty, securityInfo.UniqueId);
        Assert.AreEqual(string.Empty, securityInfo.UniqueIdType);
    }

    [TestMethod]
    public void SecurityInfo_CanSetAndGetProperties()
    {
        // Arrange
        var securityInfo = new SecurityInfo();
        var uniqueId = "XYZ";
        var uniqueIdType = "CUSIP";

        // Act
        securityInfo.UniqueId = uniqueId;
        securityInfo.UniqueIdType = uniqueIdType;

        // Assert
        Assert.AreEqual(uniqueId, securityInfo.UniqueId);
        Assert.AreEqual(uniqueIdType, securityInfo.UniqueIdType);
    }
}