using Microsoft.VisualStudio.TestTools.UnitTesting;
using OFXSDK.Parsing.Parsers;
using OFXSDK.Core.Models;
using System.IO;
using System.Text;

namespace OFXSDK.Parsing.Tests;

[TestClass]
public class OFX2ParserTests
{
    [TestMethod]
    public void OFX2Parser_Parse_ValidOFXData_ReturnsOFXDocument()
    {
        // Arrange
        var parser = new OFX2Parser();
        var ofxData = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<OFX>
  <SIGNONMSGSRSV1>
    <SONRS>
      <STATUS>
        <CODE>0</CODE>
        <SEVERITY>INFO</SEVERITY>
      </STATUS>
      <DTSERVER>20240403120000</DTSERVER>
      <LANGUAGE>ENG</LANGUAGE>
      <FI>
        <ORG>Bank of America</ORG>
        <FID>12345</FID>
      </FI>
    </SONRS>
  </SIGNONMSGSRSV1>
  <BANKMSGSRSV1>
    <STMTTRNRS>
      <STMTRS>
        <BANKACCTFROM>
          <BANKID>112233</BANKID>
          <ACCTID>998877</ACCTID>
          <ACCTTYPE>CHECKING</ACCTTYPE>
        </BANKACCTFROM>
        <BANKTRANLIST>
          <STMTTRN>
            <TRNTYPE>DEBIT</TRNTYPE>
            <DTPOSTED>20240402</DTPOSTED>
            <TRNAMT>-100.00</TRNAMT>
            <FITID>ABC12345</FITID>
            <NAME>Target</NAME>
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
    public void OFX2Parser_ParseFile_ValidFilePath_ReturnsOFXDocument()
    {
        // Arrange
        var parser = new OFX2Parser();
        var filePath = "test2.ofx";
        var ofxData = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<OFX>
  <SIGNONMSGSRSV1>
    <SONRS>
      <STATUS>
        <CODE>0</CODE>
        <SEVERITY>INFO</SEVERITY>
      </STATUS>
      <DTSERVER>20240403120000</DTSERVER>
      <LANGUAGE>ENG</LANGUAGE>
      <FI>
        <ORG>Bank of America</ORG>
        <FID>12345</FID>
      </FI>
    </SONRS>
  </SIGNONMSGSRSV1>
</OFX>";

        File.WriteAllText(filePath, ofxData, Encoding.UTF8);

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
    public void OFX2Parser_Parse_EmptyOFXData_ThrowsArgumentException()
    {
        // Arrange
        var parser = new OFX2Parser();
        var ofxData = string.Empty;

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => parser.Parse(ofxData));
    }
}