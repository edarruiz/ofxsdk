namespace EDarruiz.OFX.SDK.Tests.Primitives;

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
public class SpecificationVersionTests : IDisposable {
    #region Ctor and Dtor
    public SpecificationVersionTests() { }

    public void Dispose() => GC.SuppressFinalize(this);
    #endregion

    #region Tests
    [Fact(DisplayName = "SpecificationVersion should have Unknown value as 0")]
    [Trait("Primitives", "SpecificationVersion enum")]
    internal void SpeficificationVersion_should_have_Unknown_value_as_0() {
        // Arrange
        var expected = 0;
        var actual = (int)SpecificationVersion.Unknown;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "SpecificationVersion should have Version102 value as 1")]
    [Trait("Primitives", "SpecificationVersion enum")]
    internal void SpeficificationVersion_should_have_Version102_value_as_1() {
        // Arrange
        var expected = 1;
        var actual = (int)SpecificationVersion.Version102;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "SpecificationVersion should have Version103 value as 2")]
    [Trait("Primitives", "SpecificationVersion enum")]
    internal void SpeficificationVersion_should_have_Version103_value_as_2() {
        // Arrange
        var expected = 2;
        var actual = (int)SpecificationVersion.Version103;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "SpecificationVersion should have Version151 value as 3")]
    [Trait("Primitives", "SpecificationVersion enum")]
    internal void SpeficificationVersion_should_have_Version151_value_as_3() {
        // Arrange
        var expected = 3;
        var actual = (int)SpecificationVersion.Version151;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "SpecificationVersion should have Version160 value as 4")]
    [Trait("Primitives", "SpecificationVersion enum")]
    internal void SpeficificationVersion_should_have_Version160_value_as_4() {
        // Arrange
        var expected = 4;
        var actual = (int)SpecificationVersion.Version160;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "SpecificationVersion should have Version203 value as 5")]
    [Trait("Primitives", "SpecificationVersion enum")]
    internal void SpeficificationVersion_should_have_Version203_value_as_5() {
        // Arrange
        var expected = 5;
        var actual = (int)SpecificationVersion.Version203;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "SpecificationVersion should have Version211 value as 6")]
    [Trait("Primitives", "SpecificationVersion enum")]
    internal void SpeficificationVersion_should_have_Version211_value_as_6() {
        // Arrange
        var expected = 6;
        var actual = (int)SpecificationVersion.Version211;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "SpecificationVersion should have Version220 value as 7")]
    [Trait("Primitives", "SpecificationVersion enum")]
    internal void SpeficificationVersion_should_have_Version220_value_as_7() {
        // Arrange
        var expected = 7;
        var actual = (int)SpecificationVersion.Version220;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "SpecificationVersion should have Version221 value as 8")]
    [Trait("Primitives", "SpecificationVersion enum")]
    internal void SpeficificationVersion_should_have_Version221_value_as_8() {
        // Arrange
        var expected = 8;
        var actual = (int)SpecificationVersion.Version221;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "SpecificationVersion should have Version230 value as 9")]
    [Trait("Primitives", "SpecificationVersion enum")]
    internal void SpeficificationVersion_should_have_Version230_value_as_9() {
        // Arrange
        var expected = 9;
        var actual = (int)SpecificationVersion.Version230;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }
    #endregion
}