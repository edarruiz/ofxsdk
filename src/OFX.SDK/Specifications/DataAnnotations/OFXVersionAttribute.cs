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
/// Represents an OFX specification version of any OFX structure declarations.
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class OFXVersionAttribute : Attribute, IOFXDataAnnotation {
    #region Ctor
    /// <summary>
    /// Initializes a new instance of the <see cref="OFXVersionAttribute"/> class with the specified OFX specification version.
    /// </summary>
    /// <param name="specification">The OFX specification version.</param>
    public OFXVersionAttribute(OFXSpecification specification) {
        Specification = specification;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the OFX specification version of the attribute.
    /// </summary>
    public OFXSpecification Specification { get; init; }
    #endregion
}
