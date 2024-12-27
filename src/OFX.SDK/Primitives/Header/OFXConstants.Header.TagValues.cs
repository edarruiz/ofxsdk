namespace OFX.SDK.Primitives.Header;

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
/// Represents the OFX constants.
/// </summary>
public sealed partial class OFXConstants {
    /// <summary>
    /// Represents the OFX header constants.
    /// </summary>
    public sealed partial class Header {

        /// <summary>
        /// Represents the OFX header tag values.
        /// </summary>
        public sealed partial class TagValues {
            /// <summary>
            /// The OFX header <c>HEADER</c> tag value.
            /// </summary>
            /// <remarks>This value applies to all 1.* specification versions.</remarks>
            [OFXSpecification(OFXSpecification.Version102)]
            [OFXSpecification(OFXSpecification.Version103)]
            [OFXSpecification(OFXSpecification.Version151)]
            [OFXSpecification(OFXSpecification.Version160)]
            public const string OFXHEADER_100 = "100";

            /// <summary>
            /// The OFX header <c>HEADER</c> tag value.
            /// </summary>
            /// <remarks>This value applies to all 2.* specification versions.</remarks>
            [OFXSpecification(OFXSpecification.Version203)]
            [OFXSpecification(OFXSpecification.Version211)]
            [OFXSpecification(OFXSpecification.Version220)]
            [OFXSpecification(OFXSpecification.Version221)]
            [OFXSpecification(OFXSpecification.Version230)]
            public const string OFXHEADER_200 = "200";

            /// <summary>
            /// The OFX header <c>DATA</c> tag value.
            /// </summary>
            /// <remarks>This value applies to all 1.* specification versions.</remarks>
            [OFXSpecification(OFXSpecification.Version102)]
            [OFXSpecification(OFXSpecification.Version103)]
            [OFXSpecification(OFXSpecification.Version151)]
            [OFXSpecification(OFXSpecification.Version160)]
            public const string DATA_OFXSGML = "OFXSGML";

            /// <summary>
            /// The OFX header <c>DATA</c> tag value.
            /// </summary>
            /// <remarks>This represents the specification version 1.0.2</remarks>
            [OFXSpecification(OFXSpecification.Version102)]
            public const string VERSION_102 = "102";

            /// <summary>
            /// The OFX header <c>DATA</c> tag value.
            /// </summary>
            /// <remarks>This represents the specification version 1.0.3</remarks>
            [OFXSpecification(OFXSpecification.Version103)]
            public const string VERSION_103 = "103";

            /// <summary>
            /// The OFX header <c>DATA</c> tag value.
            /// </summary>
            /// <remarks>This represents the specification version 1.5.1</remarks>
            [OFXSpecification(OFXSpecification.Version151)]
            public const string VERSION_151 = "151";

            /// <summary>
            /// The OFX header <c>DATA</c> tag value.
            /// </summary>
            /// <remarks>This represents the specification version 1.6</remarks>
            [OFXSpecification(OFXSpecification.Version160)]
            public const string VERSION_160 = "160";

            /// <summary>
            /// The OFX header <c>SECURITY</c> tag value.
            /// </summary>
            /// <remarks>Represents no application-level security.</remarks>
            public const OFXSecurity SECURITY_NONE = OFXSecurity.None;

            /// <summary>
            /// The OFX header <c>SECURITY</c> tag value.
            /// </summary>
            /// <remarks>Represents Type 1 application-level security.</remarks>
            public const OFXSecurity SECURITY_TYPE1 = OFXSecurity.Type1;

            /// <summary>
            /// The OFX header <c>ENCODING</c> tag value.
            /// </summary>
            /// <remarks>Represents the Unicode text encoding.</remarks>
            public const OFXEncoding ENCODING_UTF8 = OFXEncoding.UTF8;

            /// <summary>
            /// The OFX header <c>ENCODING</c> tag value.
            /// </summary>
            /// <remarks>Represents the US ASCII text encoding.</remarks>
            public const OFXEncoding ENCODING_USASCII = OFXEncoding.USASCII;

            /// <summary>
            /// The OFX header <c>CHARSET</c> tag value.
            /// </summary>
            /// <remarks>Represents the ISO 8859-1 character set.</remarks>
            public const OFXCharset CHARSET_ISO_8859_1 = OFXCharset.ISO_8859_1;

            /// <summary>
            /// The OFX header <c>CHARSET</c> tag value.
            /// </summary>
            /// <remarks>Represents the Windows-1252 character set.</remarks>
            public const OFXCharset CHARSET_WIN1252 = OFXCharset.WIN_1252;

            /// <summary>
            /// The OFX header <c>CHARSET</c> tag value.
            /// </summary>
            /// <remarks>No character set is specified.</remarks>
            public const OFXCharset CHARSET_NONE = OFXCharset.None;

            /// <summary>
            /// The OFX header <c>COMPRESSION</c> tag value.
            /// </summary>
            /// <remarks>A future version of the specification will define compression (was never defined).</remarks>
            public const OFXCompression COMPRESSION_NONE = OFXCompression.None;

            /// <summary>
            /// The OFX header <c>OLDFILEUID</c> tag value.
            /// </summary>
            /// <remarks>OLDFILEUID identifies the last request and response that was received
            /// and processed by the client.</remarks>
            public const string OLDFILEUID_NONE = "NONE";

            /// <summary>
            /// The OFX header <c>NEWFILEUID</c> tag value.
            /// </summary>
            /// <remarks>NEWFILEUID uniquely identifies this request file.</remarks>
            public const string NEWFILEUID_NONE = "NONE";
        }
    }
}
