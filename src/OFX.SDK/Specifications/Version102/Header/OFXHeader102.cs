namespace OFX.SDK.Specifications.Version102;

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

/// <summary>
/// Represents the OFX file header for version 1.0.2.
/// </summary>
public sealed record OFXHeader102 : OFXHeaderBlock {
    #region Properties
    /// <summary>
    /// Gets the value of the <c>DATA</c> header tag, which specifies the content type, in this case <c>OFXSGML</c>.
    /// </summary>
    /// <remarks>You should add new values for a DATA tag only when you introduce an entirely new syntax. In the case of
    /// OFXSGML, a new syntax would have to be non-SGML compliant to warrant a new DATA value.It is
    /// possible that there will be more than one syntax in use at the same time to meet different needs.</remarks>
    public string Data { get; init; } = OFXConstants.Header.TagValues.DATA_OFXSGML;

    /// <summary>
    /// Gets the value of the <c>ENCODING</c> header tag, which defines the character encoding of the OFX data block.
    /// </summary>
    public OFXEncoding Encoding { get; init; } = OFXEncoding.USASCII;

    /// <summary>
    /// Gets the value of the <c>CHARSET</c> header tag, which defines the character set used for character data.
    /// </summary>
    public OFXCharset Charset { get; init; } = OFXCharset.WIN_1252;

    /// <summary>
    /// Gets the value of the <c>COMPRESSION</c> header tag, which specifies the compression type used for the OFX data block.
    /// </summary>
    public OFXCompression Compression { get; init; } = OFXCompression.None;
    #endregion

    #region Overrides
    /// <inheritdoc/>
    public override OFXSpecification Version => OFXSpecification.Version102;
    #endregion
}
