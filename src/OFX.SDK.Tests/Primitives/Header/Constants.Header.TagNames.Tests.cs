namespace OFX.SDK.Tests.Primitives.Header;

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
public class ConstantsHeaderTagNamesTests : IDisposable {
    #region Ctor and Dtor
    public ConstantsHeaderTagNamesTests() { }

    public void Dispose() => GC.SuppressFinalize(this);
    #endregion

    #region Tests
    [Fact(DisplayName = "OFXHEADER tag name should be 'OFXHEADER'")]
    [Trait("Header", "Tag Names")]
    internal void OFXHEADER_tag_name_should_be_OFXHEADER() {
        // Arrange
        var expected = "OFXHEADER";
        var actual = Constants.Header.TagNames.OFXHEADER;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "DATA tag name should be 'DATA'")]
    [Trait("Header", "Tag Names")]
    internal void DATA_tag_name_should_be_DATA() {
        // Arrange
        var expected = "DATA";
        var actual = Constants.Header.TagNames.DATA;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "VERSION tag name should be 'VERSION'")]
    [Trait("Header", "Tag Names")]
    internal void VERSION_tag_name_should_be_VERSION() {
        // Arrange
        var expected = "VERSION";
        var actual = Constants.Header.TagNames.VERSION;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "SECURITY tag name should be 'SECURITY'")]
    [Trait("Header", "Tag Names")]
    internal void SECURITY_tag_name_should_be_SECURITY() {
        // Arrange
        var expected = "SECURITY";
        var actual = Constants.Header.TagNames.SECURITY;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "ENCODING tag name should be 'ENCODING'")]
    [Trait("Header", "Tag Names")]
    internal void ENCODING_tag_name_should_be_ENCODING() {
        // Arrange
        var expected = "ENCODING";
        var actual = Constants.Header.TagNames.ENCODING;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "CHARSET tag name should be 'CHARSET'")]
    [Trait("Header", "Tag Names")]
    internal void CHARSET_tag_name_should_be_CHARSET() {
        // Arrange
        var expected = "CHARSET";
        var actual = Constants.Header.TagNames.CHARSET;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "COMPRESSION tag name should be 'COMPRESSION'")]
    [Trait("Header", "Tag Names")]
    internal void COMPRESSION_tag_name_should_be_COMPRESSION() {
        // Arrange
        var expected = "COMPRESSION";
        var actual = Constants.Header.TagNames.COMPRESSION;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "OLDFILEUID tag name should be 'OLDFILEUID'")]
    [Trait("Header", "Tag Names")]
    internal void OLDFILEUID_tag_name_should_be_OLDFILEUID() {
        // Arrange
        var expected = "OLDFILEUID";
        var actual = Constants.Header.TagNames.OLDFILEUID;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "NEWFILEUID tag name should be 'NEWFILEUID'")]
    [Trait("Header", "Tag Names")]
    internal void NEWFILEUID_tag_name_should_be_NEWFILEUID() {
        // Arrange
        var expected = "NEWFILEUID";
        var actual = Constants.Header.TagNames.NEWFILEUID;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }
    #endregion
}
