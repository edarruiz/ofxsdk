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
/// Represents the OFX constants.
/// </summary>
public sealed partial class Constants {
    /// <summary>
    /// Represents the OFX header constants.
    /// </summary>
    public sealed partial class Header {

        /// <summary>
        /// Represents the OFX header tag values.
        /// </summary>
        public sealed class TagValues {
            /// <summary>
            /// The OFX header <c>DATA</c> tag value.
            /// </summary>
            /// <remarks>This value applies to all 1.* specification versions.</remarks>
            public const string DATA_OFXSGML = "OFXSGML";

            /// <summary>
            /// The OFX header <c>DATA</c> tag value.
            /// </summary>
            /// <remarks>This represents the specification version 1.0.2</remarks>
            public const string VERSION_102 = "102";

            /// <summary>
            /// The OFX header <c>DATA</c> tag value.
            /// </summary>
            /// <remarks>This represents the specification version 1.0.3</remarks>
            public const string VERSION_103 = "103";

            /// <summary>
            /// The OFX header <c>DATA</c> tag value.
            /// </summary>
            /// <remarks>This represents the specification version 1.5.1</remarks>
            public const string VERSION_151 = "151";

            /// <summary>
            /// The OFX header <c>DATA</c> tag value.
            /// </summary>
            /// <remarks>This represents the specification version 1.6</remarks>
            public const string VERSION_160 = "160";

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
