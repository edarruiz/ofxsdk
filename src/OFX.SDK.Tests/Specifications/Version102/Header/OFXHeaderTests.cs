using System;
using OFX.SDK.Reflection;
using OFX.SDK.Specifications;
using OFX.SDK.Specifications.Version102;
using Xunit;

namespace OFX.SDK.Tests.Specifications.Version102.Header;

#region BSD-3 Copyright Information
/*
  Copyright (c) 2022-2024, Eric Roberto Darruiz
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without
  modification, are permitted provided that the following conditions are met:
  
  1. Redistributions of source code must retain the above copyright notice, this
     list of conditions and the following disclaimer.
  
  2. Redistributions in binary form must reproduce the above copyright notice,
     this list of conditions and the following disclaimer in the documentation
     and/or other materials provided with the distribution.
  
  3. Neither the name of the copyright holder nor the names of its
     contributors may be used to endorse or promote products derived from
     this software without specific prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
  AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
  DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
  FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
  DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
  SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
  CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
  OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
  OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

public class OFXHeaderTests {
    #region Ctor Tests
    [Fact(DisplayName = "Ctor: throw exception when CHARSET is null")]
    [Trait("OFXHeader Ctor", "CHARSET exception")]
    public void Ctor_ThrowArgumentNullException_WhenParameterCHARSETIsNull() {
        // Arrange
        Action action = () => _ = new OFXHeader(OFXHeaderSecurity.None, OFXHeaderEncoding.UNICODE, null, string.Empty, string.Empty);
        var expected = "Value cannot be null. (Parameter 'charset')";

        // Act
        var result = Assert.Throws<ArgumentNullException>(action);

        // Assert
        Assert.Equal(expected, result.Message);
    }

    [Fact(DisplayName = "Ctor: throw exception when OLDFILEUID is null")]
    [Trait("OFXHeader Ctor", "OLDFILEUID exception")]
    public void Ctor_ThrowArgumentNullException_WhenParameterOLDFILEUIDIsNull() {
        // Arrange
        Action action = () => _ = new OFXHeader(OFXHeaderSecurity.None, OFXHeaderEncoding.UNICODE, string.Empty, null, string.Empty);
        var expected = "Value cannot be null. (Parameter 'oldfileuid')";

        // Act
        var result = Assert.Throws<ArgumentNullException>(action);

        // Assert
        Assert.Equal(expected, result.Message);
    }

    [Fact(DisplayName = "Ctor: throw exception when NEWFILEUID is null")]
    [Trait("OFXHeader Ctor", "NEWFILEUID exception")]
    public void Ctor_ThrowArgumentNullException_WhenParameterNEWFILEUIDIsNull() {
        // Arrange
        Action action = () => _ = new OFXHeader(OFXHeaderSecurity.None, OFXHeaderEncoding.UNICODE, string.Empty, String.Empty, null!);
        var expected = "Value cannot be null. (Parameter 'newfileuid')";

        // Act
        var result = Assert.Throws<ArgumentNullException>(action);

        // Assert
        Assert.Equal(expected, result.Message);
    }
    #endregion

    #region OFX Attribute Version Tests
    [Fact(DisplayName = "Get OFX version from Struct")]
    public void Get_OFXVersion_FromStruct() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXVersion();

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region OFXTag Attribute Tag Name Tests
    [Fact(DisplayName = "Get OFX tag name from OFXHEADER property")]
    public void Get_OFXTagTagName_FromOFXHEADERProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "OFXHEADER:";

        // Act
        var result = actual.GetOFXTagName(nameof(OFXHeader.OFXHEADER));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag name from DATA property")]
    public void Get_OFX_TagName_FromDATAProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "DATA:";

        // Act
        var result = actual.GetOFXTagName(nameof(OFXHeader.DATA));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag name from VERSION property")]
    public void Get_OFX_TagName_FromVERSIONProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "VERSION:";

        // Act
        var result = actual.GetOFXTagName(nameof(OFXHeader.VERSION));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag name from SECURITY property")]
    public void Get_OFX_TagName_FromSECURITYProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "SECURITY:";

        // Act
        var result = actual.GetOFXTagName(nameof(OFXHeader.SECURITY));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag name from ENCODING property")]
    public void Get_OFX_TagName_FromENCODINGProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "ENCODING:";

        // Act
        var result = actual.GetOFXTagName(nameof(OFXHeader.ENCODING));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag name from CHARSET property")]
    public void Get_OFX_TagName_FromCHARSETProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "CHARSET:";

        // Act
        var result = actual.GetOFXTagName(nameof(OFXHeader.CHARSET));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag name from COMPRESSION property")]
    public void Get_OFX_TagName_FromCOMPRESSIONProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "COMPRESSION:";

        // Act
        var result = actual.GetOFXTagName(nameof(OFXHeader.COMPRESSION));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag name from OLDFILEUID property")]
    public void Get_OFX_TagName_FromOLDFILEUIDProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "OLDFILEUID:";

        // Act
        var result = actual.GetOFXTagName(nameof(OFXHeader.OLDFILEUID));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag name from NEWFILEUID property")]
    public void Get_OFX_TagName_FromNEWFILEUIDProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "NEWFILEUID:";

        // Act
        var result = actual.GetOFXTagName(nameof(OFXHeader.NEWFILEUID));

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region OFXTag Attribute Tag Version Tests
    [Fact(DisplayName = "Get OFX tag version from OFXHEADER property")]
    public void Get_OFXTagVersion_FromOFXHEADERProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXTagVersion(nameof(OFXHeader.OFXHEADER));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag version from DATA property")]
    public void Get_OFXTagVersion_FromDATAProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXTagVersion(nameof(OFXHeader.DATA));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag version from SECURITY property")]
    public void Get_OFXTagVersion_FromSECURITYProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXTagVersion(nameof(OFXHeader.SECURITY));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag version from VERSION property")]
    public void Get_OFXTagVersion_FromVERSIONProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXTagVersion(nameof(OFXHeader.VERSION));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag version from ENCODING property")]
    public void Get_OFXTagVersion_FromENCODINGProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXTagVersion(nameof(OFXHeader.ENCODING));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag version from CHARSET property")]
    public void Get_OFXTTagVersion_FromCHARSETProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXTagVersion(nameof(OFXHeader.CHARSET));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag version from COMPRESSION property")]
    public void Get_OFXTagVersion_FromCOMPRESSIONProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXTagVersion(nameof(OFXHeader.COMPRESSION));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag version from OLDFILEUID property")]
    public void Get_OFXTagVersion_FromOLDFILEUIDProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXTagVersion(nameof(OFXHeader.OLDFILEUID));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag version from NEWFILEUID property")]
    public void Get_OFXTagVersion_FromNEWFILEUIDProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXTagVersion(nameof(OFXHeader.NEWFILEUID));

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region OFXTag Tag Header Tests
    [Fact(DisplayName = "Get OFXTag tag header from OFXHEADER property")]
    public void Get_OFXTagHeader_FromOFXHEADERProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = true;

        // Act
        var result = actual.IsOFXTagHeader(nameof(OFXHeader.OFXHEADER));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag header from DATA property")]
    public void Get_OFX_TagHeader_FromDATAProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = true;

        // Act
        var result = actual.IsOFXTagHeader(nameof(OFXHeader.DATA));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag header from VERSION property")]
    public void Get_OFX_TagHeader_FromVERSIONProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = true;

        // Act
        var result = actual.IsOFXTagHeader(nameof(OFXHeader.VERSION));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX header name from SECURITY property")]
    public void Get_OFX_TagHeader_FromSECURITYProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = true;

        // Act
        var result = actual.IsOFXTagHeader(nameof(OFXHeader.SECURITY));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag header from ENCODING property")]
    public void Get_OFX_TagHeader_FromENCODINGProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = true;

        // Act
        var result = actual.IsOFXTagHeader(nameof(OFXHeader.ENCODING));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX tag header from CHARSET property")]
    public void Get_OFX_TagHeader_FromCHARSETProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = true;

        // Act
        var result = actual.IsOFXTagHeader(nameof(OFXHeader.CHARSET));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX header from COMPRESSION property")]
    public void Get_OFX_TagHeader_FromCOMPRESSIONProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = true;

        // Act
        var result = actual.IsOFXTagHeader(nameof(OFXHeader.COMPRESSION));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX header name from OLDFILEUID property")]
    public void Get_OFX_TagHeader_FromOLDFILEUIDProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = true;

        // Act
        var result = actual.IsOFXTagHeader(nameof(OFXHeader.OLDFILEUID));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Get OFX header name from NEWFILEUID property")]
    public void Get_OFX_TagHeader_FromNEWFILEUIDProperty() {
        // Arrange
        var actual = new OFXHeader();
        var expected = true;

        // Act
        var result = actual.IsOFXTagHeader(nameof(OFXHeader.NEWFILEUID));

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region Test Default Values
    [Fact(DisplayName = "Test default value of property OFXHEADER")]
    public void Test_DefaultValue_PropertyOFXHEADER() {
        // Arrange
        var actual = OFXHeader.OFXHEADER;
        var expected = "100";

        // Act

        // Assert
        Assert.Equal(actual, expected);
    }

    [Fact(DisplayName = "Test default value of property DATA")]
    public void Test_DefaultValue_PropertyDATA() {
        // Arrange
        var actual = OFXHeader.DATA;
        var expected = "OFXSGML";

        // Act

        // Assert
        Assert.Equal(actual, expected);
    }

    [Fact(DisplayName = "Test default value of property VERSION")]
    public void Test_DefaultValue_PropertyVERSION() {
        // Arrange
        var actual = OFXHeader.VERSION;
        var expected = "102";

        // Act

        // Assert
        Assert.Equal(actual, expected);
    }

    [Fact(DisplayName = "Test default value of property SECURITY")]
    public void Test_DefaultValue_PropertySECURITY() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXHeaderSecurity.None;

        // Act
        var result = actual.SECURITY;

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Test default value of property ENCODING")]
    public void Test_DefaultValue_PropertyENCODING() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXHeaderEncoding.USASCII;

        // Act
        var result = actual.ENCODING;

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Test default value of property CHARSET")]
    public void Test_DefaultValue_PropertyCHARSET() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "1252";

        // Act
        var result = actual.CHARSET;

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Test default value of property COMPRESSION")]
    public void Test_DefaultValue_PropertyCOMPRESSION() {
        // Arrange
        var actual = OFXHeader.COMPRESSION;
        var expected = string.Empty;

        // Act

        // Assert
        Assert.Equal(actual, expected);
    }

    [Fact(DisplayName = "Test default value of property OLDFILEUID")]
    public void Test_DefaultValue_PropertyOLDFILEUID() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "NONE";

        // Act
        var result = actual.OLDFILEUID;

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact(DisplayName = "Test default value of property NEWFILEUID")]
    public void Test_DefaultValue_PropertyNEWFILEUID() {
        // Arrange
        var actual = new OFXHeader();
        var expected = "NONE";

        // Act
        var result = actual.NEWFILEUID;

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion
}