namespace EDarruiz.OFX.SDK.Tests.Specifications.Version102.Header;

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
public class HeaderTests : IDisposable {
    #region Ctor and Dtor
    public HeaderTests() { }

    public void Dispose() => GC.SuppressFinalize(this);
    #endregion

    #region Tests

    [Fact(DisplayName = "Default OFXHeader should return OFX100")]
    [Trait("Specifications", "Header v1.0.2")]
    internal void OFXHeader_ShouldReturnOFX100() {
        // Arrange
        var header = new Header102();
        var expected = HeaderVersion.OFX100;

        // Act
        var actual = header.OFXHeader;

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Default Version should return Version102")]
    [Trait("Specifications", "Header v1.0.2")]
    internal void Version_ShouldReturnVersion102() {
        // Arrange
        var header = new Header102();
        var expected = SpecificationVersion.Version102;

        // Act
        var actual = header.Version;

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Default Security should return None")]
    [Trait("Specifications", "Header v1.0.2")]
    internal void Security_ShouldReturnNone() {
        // Arrange
        var header = new Header102();
        var expected = HeaderSecurity.None;

        // Act
        var actual = header.Security;

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Default OldFileUID should return None")]
    [Trait("Specifications", "Header v1.0.2")]
    internal void OldFileUID_ShouldReturnNone() {
        // Arrange
        var header = new Header102();
        var expected = Constants.Header.TagValues.OLDFILEUID_NONE;

        // Act
        var actual = header.OldFileUID;

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Default NewFileUID should return None")]
    [Trait("Specifications", "Header v1.0.2")]
    internal void NewFileUID_ShouldReturnNone() {
        // Arrange
        var header = new Header102();
        var expected = Constants.Header.TagValues.NEWFILEUID_NONE;

        // Act
        var actual = header.NewFileUID;

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Default Data should return OFXSGML")]
    [Trait("Specifications", "Header v1.0.2")]
    internal void Data_ShouldReturnOFXSGML() {
        // Arrange
        var header = new Header102();
        var expected = Constants.Header.TagValues.DATA_OFXSGML;

        // Act
        var actual = header.Data;

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Default Encoding should return USASCII")]
    [Trait("Specifications", "Header v1.0.2")]
    internal void Encoding_ShouldReturnUSASCII() {
        // Arrange
        var header = new Header102();
        var expected = HeaderEncoding.USASCII;

        // Act
        var actual = header.Encoding;

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Default Charset should return WIN_1252")]
    [Trait("Specifications", "Header v1.0.2")]
    internal void Charset_ShouldReturnWIN_1252() {
        // Arrange
        var header = new Header102();
        var expected = HeaderCharset.WIN_1252;

        // Act
        var actual = header.Charset;

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Default Compression should return None")]
    [Trait("Specifications", "Header v1.0.2")]
    internal void Compression_ShouldReturnNone() {
        // Arrange
        var header = new Header102();
        var expected = HeaderCompression.None;

        // Act
        var actual = header.Compression;

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    #endregion
}
