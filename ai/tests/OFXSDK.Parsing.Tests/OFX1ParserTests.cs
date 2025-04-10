using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Parsing.Parsers;
using OFXSDK.Core.Models;
using System.IO;
using System.Text;

namespace OFXSDK.Parsing.Tests;

[TestClass]
public class OFX1ParserTests
{
    [TestMethod]
    public void OFX1Parser_Parse_ValidOFXData_ReturnsOFXDocument()
    {
        // Arrange
        var parser = new OFX1Parser();
        var ofxData = @"OFXHEADER:100
DATA:OFXSGML
VERSION:102
SECURITY:NONE
ENCODING:USASCII
CHARSET:1252
<OFX>
<SIGNONMSGSRSV1>
<SONRS>
<STATUS>
<CODE>0
<SEVERITY>INFO
</STATUS>
<DTSERVER>20240403120000
<LANGUAGE>ENG
<FI>
<ORG>Bank of America
<FID>12345
</FI>
</SONRS>
</SIGNONMSGSRSV1>
<BANKMSGSRSV1>
<STMTTRNRS>
<STMTRS>
<BANKACCTFROM>
<BANKID>112233
<ACCTID>998877
<ACCTTYPE>CHECKING
</BANKACCTFROM>
<BANKTRANLIST>
<STMTTRN>
<TRNTYPE>DEBIT
<DTPOSTED>20240402
<TRNAMT>-100.00
<FITID>ABC12345
<NAME>Target
</STMTTRN>
</BANKTRANLIST>
</STMTRS>
</STMTTRNRS>
</BANKMSGSRSV1>
</OFX>";

        // Act
        var document = parser.Parse(ofxData);

        // Assert
        Assert.IsNotNull(document);
        Assert.IsNotNull(document.SignOn);
        Assert.IsNotNull(document.Banking);
        Assert.AreEqual("Bank of America", document.SignOn.InstitutionName);
        Assert.AreEqual("-100.00", document.Banking.Statement.Transactions[0].Amount.ToString());
    }

    [TestMethod]
    public void OFX1Parser_ParseFile_ValidFilePath_ReturnsOFXDocument()
    {
        // Arrange
        var parser = new OFX1Parser();
        var filePath = "test.ofx";
        var ofxData = @"OFXHEADER:100
DATA:OFXSGML
VERSION:102
SECURITY:NONE
ENCODING:USASCII
CHARSET:1252
<OFX>
<SIGNONMSGSRSV1>
<SONRS>
<STATUS>
<CODE>0
<SEVERITY>INFO
</STATUS>
<DTSERVER>20240403120000
<LANGUAGE>ENG
<FI>
<ORG>Bank of America
<FID>12345
</FI>
</SONRS>
</SIGNONMSGSRSV1>
</OFX>";

        File.WriteAllText(filePath, ofxData, Encoding.ASCII);

        // Act
        var document = parser.ParseFile(filePath);

        // Assert
        Assert.IsNotNull(document);
        Assert.IsNotNull(document.SignOn);
        Assert.AreEqual("Bank of America", document.SignOn.InstitutionName);

        // Cleanup
        File.Delete(filePath);
    }

    [TestMethod]
    public void OFX1Parser_Parse_EmptyOFXData_ThrowsArgumentException()
    {
        // Arrange
        var parser = new OFX1Parser();
        var ofxData = string.Empty;

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => parser.Parse(ofxData));
    }
}