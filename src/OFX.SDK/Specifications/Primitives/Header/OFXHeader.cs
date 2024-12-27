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
/// <remarks>
/// <para>The contents of an Open Financial Exchange file consist of a simple set of headers followed by contents defined by that header.</para>
/// <para>For SGML type files, the Open Financial Exchange headers are in a simple tag:value syntax and terminated by a blank line.
/// Open Financial Exchange always sends headers unencrypted, even if application-level encryption is used 
/// for the remaining contents.The language and character set used for the headers is the same as the 
/// preceding MIME headers.</para>
/// <para>The first entry will always be OFXHEADER with a version number. This entry identifies the contents as an Open Financial Exchange 
/// file and provides the version number of the Open Financial Exchange headers that follow(not the version number of the contents).
/// For example:</para>
/// <code>OFXHEADER:100</code>
/// <para>Open Financial Exchange headers can contain the following tags.</para>
/// <code>
/// DATA:
/// VERSION:
/// SECURITY:
/// ENCODING:
/// CHARSET:
/// COMPRESSION:
/// OLDFILEUID:
/// NEWFILEUID:
/// </code>
/// <para>A blank line follows the last header. Then (for type OFXSGML), the SGML-readable data begins with the <c>&lt;OFX&gt;</c> tag.</para>
/// </remarks>
internal readonly record struct OFXHeader {
    #region Ctor

    /// <summary>
    /// Initializes a new instance of the <see cref="OFXHeader"/> struct.
    /// </summary>
    public OFXHeader() {
        Data = OFXHeaderDataFormat.SGML;
    }

    #endregion

    #region Properties
    /// <summary>
    /// Gets the OFX header data type.
    /// </summary>
    public OFXHeaderDataFormat Data { get; init; }

    #endregion
}
