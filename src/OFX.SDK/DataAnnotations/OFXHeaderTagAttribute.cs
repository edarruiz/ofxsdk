namespace OFX.SDK.DataAnnotations;

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
/// Represents an OFX tag for any OFX header structure declarations.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
public sealed class OFXHeaderTagAttribute<TValue> : OFXAbstractTagAttribute {
    #region Ctor
    /// <summary>
    /// Initializes a new instance of the <see cref="OFXHeaderTagAttribute{TValue}"/> class with the specified tag name.
    /// </summary>
    /// <param name="name">The name of the OFX header tag.</param>
    /// <param name="value">The value of the OFX header tag.</param>
    /// <exception cref="ArgumentException">When the <paramref name="name"/> is <see langword="null"/>, empty, 
    /// or consists only of white-space characters.</exception>
    public OFXHeaderTagAttribute(string name, TValue value) : base(name) {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        Scope = OFXTagScope.Header;
        Value = value;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the value of the OFX header tag.
    /// </summary>
    public TValue Value { get; init; }
    #endregion
}
