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

public class HeaderVersionTests {
    [Fact(DisplayName = "HeaderVersion should have OFX100 value as 0")]
    [Trait("Category", "HeaderVersion")]
    public void HeaderVersion_Should_Have_OFX100_Value_As_0() {
        // Arrange
        var expected = 0;

        // Act
        var actual = (int)HeaderVersion.OFX100;

        // Assert
        actual
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "HeaderVersion should have OFX200 value as 1")]
    [Trait("Category", "HeaderVersion")]
    public void HeaderVersion_Should_Have_OFX200_Value_As_1() {
        // Arrange
        var expected = 1;

        // Act
        var actual = (int)HeaderVersion.OFX200;

        // Assert
        actual
            .Should()
            .Be(expected);
    }
}
