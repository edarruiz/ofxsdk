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
/// Represents the OFX header data format.
/// </summary>
internal enum OFXHeaderDataFormat {

    /// <summary>
    /// The header is in SGML format (Versions 1.0, 1.0.2, 1.0.3, 1.5.1 and 1.6).
    /// </summary>
    /// <remarks></remarks>
    [OFXValue<string>("OFXSGML")]
    SGML = 0,

    /// <summary>
    /// The header is in XML format (Versions 2.0+).
    /// </summary>
    /// <remarks>When the specification version of the OFX file is not SGML, the tag &lt;DATA&gt; 
    /// is ommited, because XML is assumed.</remarks>
    [OFXValue<string>("")]
    [OFXDescription("The header is in XML format, the tag &lt;DATA&gt; is ommited in the XML file.")]
    XML = 1
}
