using System.Reflection;
using OFX.SDK.Specifications;

namespace OFX.SDK.Reflection;

#region BSD-3 Copyright Information
/*
  Copyright (c) 2022, Eric Roberto Darruiz
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without
  modification, are permitted provided that the following conditions are met:
  
  1. Redistributions of source code must retain the above copyright notice, this
     list of conditions and the following disclaimer.
  
  2. Redistributions in binary form must reproduce the above copyright notice,
     this list of conditions and the following disclaimer in the documentation
     and/or other materials provided with the distribution.
  
  3. Neither the name of the copyright holder nor the names of its
     contributors may be used to endorse or promote products derived from
     this software without specific prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
  AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
  DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
  FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
  DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
  SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
  CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
  OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
  OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

/// <summary>
/// Represents the reflection attributes reader for any kinds of objects.
/// </summary>
public static class ReflectionAttributeReader {
    #region Helpers
    /// <summary>
    /// Returns the information from an attribute annotation applied to any object field or property.
    /// </summary>
    /// <typeparam name="TSource">The generic type having the attribute annotation.</typeparam>
    /// <typeparam name="TAttribute">The annotation attribute class reference.</typeparam>
    /// <param name="source">The generic type having the attribute annotation.</param>
    /// <param name="propertyName">Name of the property which the attribute annotation is applied.</param>
    /// <returns>Returns if found, the attribute information from the field when the type is an <see cref="Enum"/>,
    /// or from the property name informed when the source type is a <see langword="class"/> or a <see langword="struct"/>.</returns>
    private static TAttribute? GetAttributeInfo<TSource, TAttribute>(TSource source, string? propertyName = null) where TAttribute : Attribute {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        TAttribute? attribute = null;
        var type = source.GetType();
        if (type.IsEnum) { // enum
#pragma warning disable CS8604 // Possible null reference argument.
            FieldInfo? fieldInfo = source.GetType().GetField(source.ToString());
#pragma warning restore CS8604 // Possible null reference argument.
            attribute = fieldInfo?.GetCustomAttribute<TAttribute>(false);
        } else if ((type.IsClass) || (type.IsValueType && !type.IsPrimitive)) { // class or struct
#pragma warning disable CS8604 // Possible null reference argument.
            PropertyInfo? propertyInfo = source.GetType().GetProperty(propertyName);
#pragma warning restore CS8604 // Possible null reference argument.
            attribute = propertyInfo?.GetCustomAttribute<TAttribute>(false);
        }

        return attribute;
    }
    #endregion

    #region OFXValueAttribute Reader
    /// <summary>
    /// Gets the value from the <see cref="OFXValueAttribute"/> annotation applied to the object.
    /// </summary>
    /// <typeparam name="T">The generic type having the <see cref="OFXValueAttribute"/> annotation.</typeparam>
    /// <param name="source">Instance of the generic type having the <see cref="OFXValueAttribute"/> annotation.</param>
    /// <returns>Returns the value assigned to the <see cref="OFXValueAttribute"/> annotation applied to the object.</returns>
    public static string? GetOFXValue<T>(this T source) {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var result = GetAttributeInfo<T, OFXValueAttribute>(source);

        return (result is null) ? null : result.Value as string;
    }
    #endregion

    #region OFXVersionAttribute Reader
    /// <summary>
    /// Gets the <see cref="OFXSpecification"/> value from the <see cref="OFXVersionAttribute"/> annotation
    /// applied to the object.
    /// </summary>
    /// <typeparam name="T">The generic type having the <see cref="OFXVersionAttribute"/> annotation.</typeparam>
    /// <param name="source">Instance of the generic type having the <see cref="OFXVersionAttribute"/> annotation.</param>
    /// <returns>Returns the <see cref="OFXSpecification"/> value assigned to the <see cref="OFXVersionAttribute"/> object annotation.</returns>
    public static OFXSpecification GetOFXVersion<T>(this T source) {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var attribute = source.GetType().GetCustomAttribute<OFXVersionAttribute>(false);

        return (attribute is null) ? OFXSpecification.Unknown : attribute.Specification;
    }
    #endregion

    #region OFXTagAttribute Reader
    /// <summary>
    /// Gets the tag name from the <see cref="OFXTagAttribute"/> annotation applied to the object.
    /// </summary>
    /// <typeparam name="T">The generic type having the <see cref="OFXTagAttribute"/> annotation.</typeparam>
    /// <param name="source">Instance of the generic type having the <see cref="OFXTagAttribute"/> annotation.</param>
    /// <param name="propertyName">Name of the property annotated.</param>
    /// <returns>Returns the tag name of the <see cref="OFXTagAttribute"/> assigned to the object annotation.</returns>
    public static string? GetOFXTagName<T>(this T source, string? propertyName = null) {

        var result = GetAttributeInfo<T, OFXTagAttribute>(source, propertyName);

        return result?.Name;
    }
    #endregion
}
