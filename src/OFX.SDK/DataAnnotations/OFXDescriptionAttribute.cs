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
/// Represents a description of any OFX structure declarations.
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public sealed class OFXDescriptionAttribute : Attribute, IOFXDataAnnotation {
    #region Ctor
    /// <summary>
    /// Initializes a new instance of the <see cref="OFXDescriptionAttribute"/> class with the specified description.
    /// </summary>
    /// <param name="description">The OFX description.</param>
    /// <exception cref="ArgumentException">When the <paramref name="description"/> is <see langword="null"/>, empty, 
    /// or consists only of white-space characters.</exception>
    public OFXDescriptionAttribute(string description) {
        ArgumentException.ThrowIfNullOrWhiteSpace(description, nameof(description));

        Description = description;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the OFX description
    /// </summary>
    public string Description { get; init; }
    #endregion
}
