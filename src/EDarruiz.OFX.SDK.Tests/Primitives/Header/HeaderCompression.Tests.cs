namespace EDarruiz.OFX.SDK.Tests.Primitives.Header;

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
public class HeaderCompressionTests : IDisposable {
    #region Ctor and Dtor
    public HeaderCompressionTests() { }

    public void Dispose() => GC.SuppressFinalize(this);
    #endregion

    #region Tests
    [Fact(DisplayName = "HeaderCompression should have None value as 0")]
    [Trait("Primitives", "Compression enum")]
    internal void HeaderCompression_should_have_None_value_as_0() {
        // Arrange
        var expected = 0;
        var actual = (int)HeaderCompression.None;

        // Act

        // Assert
        actual
            .Should()
            .Be(expected);
    }
    #endregion
}
