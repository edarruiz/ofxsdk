namespace OFX.SDK.Tests.IO;

#region MIT License Information
/*
 *
 * MIT License
 *
 * Copyright (c) 2020-2025 Eric Roberto Darruiz
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 */
#endregion

[ExcludeFromCodeCoverage]
public class OFXFileTests : IDisposable {
    #region Ctor and Dtor
    public OFXFileTests() { }

    public void Dispose() => GC.SuppressFinalize(this);
    #endregion

    #region Tests
    [Fact(DisplayName = "Constructor should throw ArgumentException when sourceFilePath is null or whitespace")]
    [Trait("OFXFile", "Constructor")]
    public void Constructor_ShouldThrowArgumentException_WhenSourceFilePathIsNullOrWhitespace() {
        // Arrange
        string sourceFilePath = " ";

        // Act
#pragma warning disable CA1806 // Do not ignore method results
        Action actual = () => new OFXFile(sourceFilePath);
#pragma warning restore CA1806 // Do not ignore method results

        // Assert
        actual
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("The value cannot be an empty string or composed entirely of whitespace. (Parameter 'sourceFilePath')");
    }

    [Fact(DisplayName = "Constructor should throw FileNotFoundException when file does not exist")]
    [Trait("OFXFile", "Constructor")]
    public void Constructor_ShouldThrowFileNotFoundException_WhenFileDoesNotExist() {
        // Arrange
        string sourceFilePath = "nonexistent.ofx";

        // Act
#pragma warning disable CA1806 // Do not ignore method results
        Action actual = () => new OFXFile(sourceFilePath);
#pragma warning restore CA1806 // Do not ignore method results

        // Assert
        actual
            .Should()
            .Throw<FileNotFoundException>()
            .WithMessage("The file 'nonexistent.ofx' does not exist.");
    }

    [Fact(DisplayName = "Constructor should initialize FilePath property")]
    [Trait("OFXFile", "Constructor")]
    public void Constructor_ShouldInitializeFilePathProperty() {
        // Arrange
        string sourceFilePath = "test.ofx";
        File.WriteAllText(sourceFilePath, "<OFX></OFX>");

        // Act
        var actual = new OFXFile(sourceFilePath);

        // Assert
        actual.FilePath
            .Should()
            .Be(sourceFilePath);

        // Cleanup
        File.Delete(sourceFilePath);
    }

    [Fact(DisplayName = "ToXml should convert OFX file to XML formatted string")]
    [Trait("OFXFile", "ToXml")]
    public void ToXml_ShouldConvertOFXFileToXMLFormattedString() {
        // Arrange
        string sourceFilePath = "test.ofx";
        string fileContent = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
            "<OFX>\r\n" +
            "  <SIGNONMSGSRSV1>\r\n" +
            "    <SONRS>\r\n" +
            "      <STATUS>\r\n" +
            "        <CODE>0\r\n" +
            "        <SEVERITY>INFO\r\n" +
            "      </STATUS>\r\n" +
            "    </SONRS>\r\n" +
            "  </SIGNONMSGSRSV1>\r\n" +
            "</OFX>\r\n";
        string expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
            "<OFX>\r\n" +
            "  <SIGNONMSGSRSV1>\r\n" +
            "    <SONRS>\r\n" +
            "      <STATUS>\r\n" +
            "        <CODE>0</CODE>\r\n" +
            "        <SEVERITY>INFO</SEVERITY>\r\n" +
            "      </STATUS>\r\n" +
            "    </SONRS>\r\n" +
            "  </SIGNONMSGSRSV1>\r\n" +
            "</OFX>\r\n";
        File.WriteAllText(sourceFilePath, fileContent);
        var ofxFile = new OFXFile(sourceFilePath);

        // Act
        var actual = ofxFile.ToXml().ToString();

        // Assert
        expected
            .Should()
            .Be(expected);

        // Cleanup
        File.Delete(sourceFilePath);
    }

    [Fact(DisplayName = "ReadFile should populate Headers correctly")]
    [Trait("OFXFile", "ReadFile")]
    public void ReadFile_ShouldPopulateHeadersCorrectly() {
        // Arrange
        string sourceFilePath = "test_headers.ofx";
        string fileContent = "OFXHEADER:100\nDATA:OFXSGML\nVERSION:102\nSECURITY:NONE\nENCODING:USASCII\nCHARSET:1252\nCOMPRESSION:NONE\nOLDFILEUID:NONE\nNEWFILEUID:NONE\n<OFX></OFX>";
        File.WriteAllText(sourceFilePath, fileContent);
        var ofxFile = new OFXFile(sourceFilePath);

        // Act
        var actual = ofxFile.Headers;

        // Assert
        actual["OFXHEADER"]
            .Should()
            .Be("100");
        actual["DATA"]
            .Should()
            .Be("OFXSGML");
        actual["VERSION"]
            .Should()
            .Be("102");
        actual["SECURITY"]
            .Should()
            .Be("NONE");
        actual["ENCODING"]
            .Should()
            .Be("USASCII");
        actual["CHARSET"]
            .Should()
            .Be("1252");
        actual["COMPRESSION"]
            .Should()
            .Be("NONE");
        actual["OLDFILEUID"]
            .Should()
            .Be("NONE");
        actual["NEWFILEUID"]
            .Should()
            .Be("NONE");

        // Cleanup
        File.Delete(sourceFilePath);
    }

    [Fact(DisplayName = "ReadFile should populate SGMLMap correctly")]
    [Trait("OFXFile", "ReadFile")]
    public void ReadFile_ShouldPopulateSGMLMapCorrectly() {
        // Arrange
        string sourceFilePath = "test_sgmlmap.ofx";
        string fileContent = "<OFX>\n<SIGNONMSGSRSV1>\n<SONRS>\n<STATUS>\n<CODE>0\n<SEVERITY>INFO\n</STATUS>\n</SONRS>\n</SIGNONMSGSRSV1>\n</OFX>";
        File.WriteAllText(sourceFilePath, fileContent);
        var ofxFile = new OFXFile(sourceFilePath);

        // Act
        var actual = ofxFile.SGMLMap;

        // Assert
        actual
            .Should()
            .BeEquivalentTo([
                new SGMLTag { Name = "OFX", Value = "OPEN_TAG", Level = 1 },
                new SGMLTag { Name = "SIGNONMSGSRSV1", Value = "OPEN_TAG", Level = 2 },
                new SGMLTag { Name = "SONRS", Value = "OPEN_TAG", Level = 3 },
                new SGMLTag { Name = "STATUS", Value = "OPEN_TAG", Level = 4 },
                new SGMLTag { Name = "CODE", Value = "0", Level = 5 },
                new SGMLTag { Name = "SEVERITY", Value = "INFO", Level = 5 },
                new SGMLTag { Name = "STATUS", Value = "CLOSE_TAG", Level = 4 },
                new SGMLTag { Name = "SONRS", Value = "CLOSE_TAG", Level = 3 },
                new SGMLTag { Name = "SIGNONMSGSRSV1", Value = "CLOSE_TAG", Level = 2 },
                new SGMLTag { Name = "OFX", Value = "CLOSE_TAG", Level = 1 }
            ], options => options.WithStrictOrdering());

        // Cleanup
        File.Delete(sourceFilePath);
    }
    #endregion
}
