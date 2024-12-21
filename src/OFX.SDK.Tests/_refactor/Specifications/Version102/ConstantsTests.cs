using OFX.SDK._refactor.Specifications.Version102;
using Xunit;

namespace OFX.SDK.Tests._refactor.Specifications.Version102;

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

public class ConstantsTests {
    #region Constant Value Tests
    [Fact(DisplayName = "Test the OFX_HEADER_TAG value")]
    public void Test_OFX_HEADER_TAG_Value() {
        // Arrange
        var actual = Constants.OFX_HEADER_TAG;
        var expected = "OFXHEADER:";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_HEADER_TAG_VALUE value")]
    public void Test_OFX_HEADER_TAG_VALUE_Value() {
        // Arrange
        var actual = Constants.OFX_HEADER_TAG_VALUE;
        var expected = "100";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_DATA_TAG value")]
    public void Test_OFX_DATA_TAG_Value() {
        // Arrange
        var actual = Constants.OFX_DATA_TAG;
        var expected = "DATA:";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_DATA_TAG_VALUE value")]
    public void Test_OFX_DATA_TAG_VALUE_Value() {
        // Arrange
        var actual = Constants.OFX_DATA_TAG_VALUE;
        var expected = "OFXSGML";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_VERSION_TAG value")]
    public void Test_OFX_VERSION_TAG_Value() {
        // Arrange
        var actual = Constants.OFX_VERSION_TAG;
        var expected = "VERSION:";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_VERSION_TAG_VALUE value")]
    public void Test_OFX_VERSION_TAG_VALUE_Value() {
        // Arrange
        var actual = Constants.OFX_VERSION_TAG_VALUE;
        var expected = "102";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_SECURITY_TAG value")]
    public void Test_OFX_SECURITY_TAG_Value() {
        // Arrange
        var actual = Constants.OFX_SECURITY_TAG;
        var expected = "SECURITY:";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_SECURITY_NONE value")]
    public void Test_OFX_SECURITY_NONE_Value() {
        // Arrange
        var actual = Constants.OFX_SECURITY_NONE;
        var expected = "NONE";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_SECURITY_TYPE1 value")]
    public void Test_OFX_SECURITY_TYPE1_Value() {
        // Arrange
        var actual = Constants.OFX_SECURITY_TYPE1;
        var expected = "TYPE1";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_ENCODING_TAG value")]
    public void Test_OFX_ENCODING_TAG_Value() {
        // Arrange
        var actual = Constants.OFX_ENCODING_TAG;
        var expected = "ENCODING:";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_ENCODING_UNICODE value")]
    public void Test_OFX_ENCODING_UNICODE_Value() {
        // Arrange
        var actual = Constants.OFX_ENCODING_UNICODE;
        var expected = "UNICODE";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_ENCODING_USASCII value")]
    public void Test_OFX_ENCODING_USASCII_Value() {
        // Arrange
        var actual = Constants.OFX_ENCODING_USASCII;
        var expected = "USASCII";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_CHARSET_TAG value")]
    public void Test_OFX_CHARSET_TAG_Value() {
        // Arrange
        var actual = Constants.OFX_CHARSET_TAG;
        var expected = "CHARSET:";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_CHARSET_TAG_VALUE value")]
    public void Test_OFX_CHARSET_TAG_VALUE_Value() {
        // Arrange
        var actual = Constants.OFX_CHARSET_TAG_VALUE;
        var expected = "1252";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_COMPRESSION_TAG value")]
    public void Test_OFX_COMPRESSION_TAG_Value() {
        // Arrange
        var actual = Constants.OFX_COMPRESSION_TAG;
        var expected = "COMPRESSION:";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_OLDFILEUID_TAG value")]
    public void Test_OFX_OLDFILEUID_TAG_Value() {
        // Arrange
        var actual = Constants.OFX_OLDFILEUID_TAG;
        var expected = "OLDFILEUID:";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_OLDFILEUID_TAG_VALUE value")]
    public void Test_OFX_OLDFILEUID_TAG_VALUE_Value() {
        // Arrange
        var actual = Constants.OFX_OLDFILEUID_TAG_VALUE;
        var expected = "NONE";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_NEWFILEUID_TAG value")]
    public void Test_OFX_NEWFILEUID_TAG_Value() {
        // Arrange
        var actual = Constants.OFX_NEWFILEUID_TAG;
        var expected = "NEWFILEUID:";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the OFX_NEWFILEUID_TAG_VALUE value")]
    public void Test_OFX_NEWFILEUID_TAG_VALUE_Value() {
        // Arrange
        var actual = Constants.OFX_NEWFILEUID_TAG_VALUE;
        var expected = "NONE";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the SIGNON_MSG_SET_REQUEST_V1 value")]
    public void Test_SIGNON_MSG_SET_REQUEST_V1_Value() {
        // Arrange
        var actual = Constants.SIGNON_MSG_SET_REQUEST_V1;
        var expected = "SIGNONMSGSRQV1";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Test the SIGNON_MSG_SET_RESPONSE_V1 value")]
    public void Test_SIGNON_MSG_SET_RESPONSE_V1_Value() {
        // Arrange
        var actual = Constants.SIGNON_MSG_SET_RESPONSE_V1;
        var expected = "SIGNONMSGSRSV1";

        // Act

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
}