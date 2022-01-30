using System;
using OFX.SDK.Reflection;
using OFX.SDK.Specifications;
using OFX.SDK.Specifications.Version102;
using Xunit;

namespace OFX.SDK.Tests.Specifications.Version102.Header;

#region BSD-3 Copyright Information
/*
  Copyright (c) 2022, Eric Roberto Darruiz
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
    #region Annotation Tests
    [Fact(DisplayName = "Get OFXVersion Attribute")]
    public void Get_OFXVersionAttribute_FromClass() {
        // Arrange
        var actual = new OFXHeader();
        var expected = OFXSpecification.Version102;

        // Act
        var result = actual.GetOFXVersion();

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region Ctor Tests
    [Fact(DisplayName = "Ctor: throw exception when CHARSET is null")]
    [Trait("OFXHeader Ctor", "CHARSET exception")]
    public void Ctor_ThrowArgumentNullException_ParameterCHARSET() {
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
    public void Ctor_ThrowArgumentNullException_ParameterOLDFILEUID() {
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
    public void Ctor_ThrowArgumentNullException_ParameterNEWFILEUID() {
        // Arrange
        Action action = () => _ = new OFXHeader(OFXHeaderSecurity.None, OFXHeaderEncoding.UNICODE, string.Empty, String.Empty, null);
        var expected = "Value cannot be null. (Parameter 'newfileuid')";

        // Act
        var result = Assert.Throws<ArgumentNullException>(action);

        // Assert
        Assert.Equal(expected, result.Message);
    }
    #endregion
}