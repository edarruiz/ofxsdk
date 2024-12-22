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
/// Represents an OFX specification version.
/// </summary>
public enum OFXSpecification {
    /// <summary>
    /// Unknown specification version.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Specification version 1.0.2, the initial version.
    /// </summary>
    /// <remarks>Version 1.0.2 (1997)</remarks>
    [OFXValue<string>("1.0.2")]
    Version102 = 1,

    /// <summary>
    /// Specification version 1.0.3, including MFA (multi-factor authentication)
    /// </summary>
    /// <remarks>Version 1.0.3 (2005) + MFA</remarks>
    [OFXValue<string>("1.0.3")]
    Version103 = 2,

    /// <summary>
    /// Specification version 1.6, last version using SGML format.
    /// </summary>
    /// <remarks>Version 1.6 (1999)</remarks>
    [OFXValue<string>("1.6")]
    Version160 = 3,

    /// <summary>
    /// Specification version 2.0.3, first version using XML.
    /// </summary>
    /// <remarks>Version 2.0.3 (2006) = 2.0.2 + MFA</remarks>
    [OFXValue<string>("2.0.3")]
    Version203 = 4,

    /// <summary>
    /// Specification version 2.1.1, equivalent to 2.1 including MFA (multi-factor authentication)
    /// </summary>
    /// <remarks>Version 2.1.1 (2006) = 2.1 + MFA</remarks>
    [OFXValue<string>("2.1.1")]
    Version211 = 5,

    /// <summary>
    /// Specification version 2.2, including OAuth.
    /// </summary>
    /// <remarks>Version 2.2 (2017) + OAuth</remarks>
    [OFXValue<string>("2.2")]
    Version220 = 6,

    /// <summary>
    /// Specification version 2.2.1, including Tax information 2.0
    /// </summary>
    /// <remarks>Version 2.2.1 (2019) + Tax 2.0</remarks>
    [OFXValue<string>("2.2.1")]
    Version221 = 7,

    /// <summary>
    /// Specification version 2.3
    /// </summary>
    /// <remarks>Version 2.3 (2020)</remarks>
    [OFXValue<string>("2.3")]
    Version230 = 8
}