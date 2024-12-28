namespace OFX.SDK;

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
/// Represents the OFX file header.
/// </summary>
public abstract record AbstractHeader {
    #region Properties
    /// <summary>
    /// Gets the value of the <c>OFXHEADER</c> header tag, which specifies the version number of the 
    /// Open Financial Exchange headers.
    /// </summary>
    /// <remarks>The OFXHEADER value should change its major number only if an existing client is unable to process the
    /// new header. This can occur because of a complete syntax change in a header, or a significant change in the
    /// semantics of an existing tag - not the entire response. A server can add new tags as long as clients can
    /// function without understanding them.</remarks>
    public abstract HeaderVersion OFXHeader { get; }

    /// <summary>
    /// Gets the value of the <c>VERSION</c> header tag, which specifies the version number of the OFX data block.
    /// </summary>
    public abstract SpecificationVersion Version { get; }

    /// <summary>
    /// Gets the value of the <c>SECURITY</c> header tag, which specifies the security level of the OFX data block.
    /// </summary>
    public virtual HeaderSecurity Security { get; init; } = HeaderSecurity.None;

    /// <summary>
    /// Gets the value of the <c>OLDFILEUID</c> header tag, which specifies the unique identifier of the previous file.
    /// </summary>
    public virtual string OldFileUID { get; init; } = Constants.Header.TagValues.NEWFILEUID_NONE;

    /// <summary>
    /// Gets the value of the <c>NEWFILEUID</c> header tag, which specifies the unique identifier of the current file.
    /// </summary>
    public virtual string NewFileUID { get; init; } = Constants.Header.TagValues.NEWFILEUID_NONE;
    #endregion
}
