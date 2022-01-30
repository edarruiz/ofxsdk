using OFX.SDK.Reflection;
using Xunit;

namespace OFX.SDK.Tests.Reflection.OFXAttributes;

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

public class ReflectionAttributeReaderTests {
    #region Tests
    [Fact(DisplayName = "Enum OFXValueAttribute Reader")]
    public void OFXValueAttributeTest() {
        // Arrange
        var actual1 = DummyEnum.FirstValue;
        var actual2 = DummyEnum.SecondValue;
        var actual3 = DummyEnum.ThirdValue;
        var expected1 = "#1 Value";
        var expected2 = "#2 Value";
        var expected3 = "#3 Value";

        // Act
        var result1 = actual1.GetOFXValueAttribute();
        var result2 = actual2.GetOFXValueAttribute();
        var result3 = actual3.GetOFXValueAttribute();

        // Assert
        Assert.Equal(expected1, result1);
        Assert.Equal(expected2, result2);
        Assert.Equal(expected3, result3);
    }
    #endregion
}

public enum DummyEnum {
    [OFXValue("#1 Value")]
    FirstValue = 0,

    [OFXValue("#2 Value")]
    SecondValue = 1,

    [OFXValue("#3 Value")]
    ThirdValue = 2
}