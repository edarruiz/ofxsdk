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
        /// Represents the OFX header tag names.
        /// </summary>
        public sealed partial class TagNames {
            /// <summary>
            /// The OFX header <c>HEADER</c> tag.
            /// </summary>
            public const string OFXHEADER = "OFXHEADER";

            /// <summary>
            /// The OFX header <c>DATA</c> tag.
            /// </summary>
            public const string DATA = "DATA";

            /// <summary>
            /// The OFX header <c>VERSION</c> tag.
            /// </summary>
            public const string VERSION = "VERSION";

            /// <summary>
            /// The OFX header <c>SECURITY</c> tag.
            /// </summary>
            public const string SECURITY = "SECURITY";

            /// <summary>
            /// The OFX header <c>ENCODING</c> tag.
            /// </summary>
            public const string ENCODING = "ENCODING";

            /// <summary>
            /// The OFX header <c>CHARSET</c> tag.
            /// </summary>
            public const string CHARSET = "CHARSET";

            /// <summary>
            /// The OFX header <c>COMPRESSION</c> tag.
            /// </summary>
            public const string COMPRESSION = "COMPRESSION";

            /// <summary>
            /// The OFX header <c>OLDFILEUID</c> tag.
            /// </summary>
            public const string OLDFILEUID = "OLDFILEUID";

            /// <summary>
            /// The OFX header <c>NEWFILEUID</c> tag.
            /// </summary>
            public const string NEWFILEUID = "NEWFILEUID";
        }
    }
}
