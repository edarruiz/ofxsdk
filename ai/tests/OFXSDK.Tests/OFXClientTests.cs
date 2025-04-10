using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OFXSDK.Tests;

[TestClass]
public class OFXClientTests {
    [TestMethod]
    public void OFXClient_Constructor_InitializesCorrectly() {
        // Arrange & Act
        var client = new OFXClient();

        // Assert
        Assert.IsNotNull(client);
    }

    [TestMethod]
    public void OFXClient_Parse_ValidString_ReturnsOFXDocument() {
        // Arrange
        var client = new OFXClient();
        var ofxData = @"OFXHEADER:100
DATA:OFXSGML
VERSION:102
<OFX>
<SIGNONMSGSRSV1>
<SONRS>
<STATUS>
<CODE>0
<SEVERITY>INFO
</STATUS>
<DTSERVER>20240301
</SONRS>
</SIGNONMSGSRSV1>
</OFX>";

        // Act
        var document = client.Parse(ofxData);

        // Assert
        Assert.IsNotNull(document);
        Assert.IsNotNull(document.SignOn);
    }

    [TestMethod]
    public void OFXClient_ParseFile_ValidFile_ReturnsOFXDocument() {
        // Arrange
        var client = new OFXClient();
        var filePath = Path.GetTempFileName();
        File.WriteAllText(filePath, @"OFXHEADER:100
DATA:OFXSGML
VERSION:102
<OFX>
<SIGNONMSGSRSV1>
<SONRS>
<STATUS>
<CODE>0
<SEVERITY>INFO
</STATUS>
<DTSERVER>20240301
</SONRS>
</SIGNONMSGSRSV1>
</OFX>");

        // Act
        var document = client.ParseFile(filePath);

        // Assert
        Assert.IsNotNull(document);
        Assert.IsNotNull(document.SignOn);

        // Cleanup
        File.Delete(filePath);
    }

    [TestMethod]
    public async Task OFXClient_ParseFileAsync_ValidFile_ReturnsOFXDocument() {
        // Arrange
        var client = new OFXClient();
        var filePath = Path.GetTempFileName();
        await File.WriteAllTextAsync(filePath, @"OFXHEADER:100
DATA:OFXSGML
VERSION:102
<OFX>
<SIGNONMSGSRSV1>
<SONRS>
<STATUS>
<CODE>0
<SEVERITY>INFO
</STATUS>
<DTSERVER>20240301
</SONRS>
</SIGNONMSGSRSV1>
</OFX>");

        // Act
        var document = await client.ParseFileAsync(filePath);

        // Assert
        Assert.IsNotNull(document);
        Assert.IsNotNull(document.SignOn);

        // Cleanup
        File.Delete(filePath);
    }
}