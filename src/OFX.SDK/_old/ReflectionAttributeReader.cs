//using System.Reflection;

namespace OFX.SDK._refactor.Reflection;
/*
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
        } else if (type.IsClass || type.IsValueType && !type.IsPrimitive) { // class or struct
            ArgumentNullException.ThrowIfNull(propertyName);
            PropertyInfo? propertyInfo = source.GetType().GetProperty(propertyName);
            attribute = propertyInfo?.GetCustomAttribute<TAttribute>(false);
        }

        return attribute;
    }
    #endregion

    #region OFXValueAttribute Reader
    /// <summary>
    /// Gets the value from the <see cref="OFXValueAttribute"/> annotation applied to the object, field or property.
    /// </summary>
    /// <typeparam name="T">The generic type having the <see cref="OFXValueAttribute"/> annotation.</typeparam>
    /// <param name="source">Instance of the generic type having the <see cref="OFXValueAttribute"/> annotation.</param>
    /// <param name="propertyName">Name of the property which the attribute annotation is applied.</param>
    /// <returns>Returns the value assigned to the <see cref="OFXValueAttribute"/> annotation applied to the object, field or property.</returns>
    public static string? GetOFXValue<T>(this T source, string? propertyName = null) {
        var result = GetAttributeInfo<T, OFXValueAttribute>(source, propertyName);

        return result is null ? null : result.Value as string;
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

        return attribute is null ? OFXSpecification.Unknown : attribute.Specification;
    }
    #endregion

    #region OFXTagAttribute Reader
    /// <summary>
    /// Gets the tag name from the <see cref="OFXTagAttribute"/> annotation applied to the object, field or property.
    /// </summary>
    /// <typeparam name="T">The generic type having the <see cref="OFXTagAttribute"/> annotation.</typeparam>
    /// <param name="source">Instance of the generic type having the <see cref="OFXTagAttribute"/> annotation.</param>
    /// <param name="propertyName">Name of the property which the attribute annotation is applied.</param>
    /// <returns>Returns the tag name of the <see cref="OFXTagAttribute"/> assigned to the object, field or property annotation.</returns>
    public static string? GetOFXTagName<T>(this T source, string? propertyName = null) {
        var result = GetAttributeInfo<T, OFXTagAttribute>(source, propertyName);

        return result?.Name;
    }

    /// <summary>
    /// Gets the tag <see cref="OFXSpecification"/> from the <see cref="OFXTagAttribute"/> annotation applied to the object, object fields or properties.
    /// </summary>
    /// <typeparam name="T">The generic type having the <see cref="OFXTagAttribute"/> annotation.</typeparam>
    /// <param name="source">Instance of the generic type having the <see cref="OFXTagAttribute"/> annotation.</param>
    /// <param name="propertyName">Name of the property which the attribute annotation is applied.</param>
    /// <returns>Returns the <see cref="OFXSpecification"/> from the <see cref="OFXTagAttribute"/> assigned to the object, field or property annotation.</returns>
    public static OFXSpecification? GetOFXTagVersion<T>(this T source, string? propertyName = null) {
        var result = GetAttributeInfo<T, OFXTagAttribute>(source, propertyName);

        return result?.Specification;
    }

    /// <summary>
    /// Check if the property of an object correspond a header tag.
    /// </summary>
    /// <typeparam name="T">The generic type having the <see cref="OFXTagAttribute"/> annotation.</typeparam>
    /// <param name="source">Instance of the generic type having the <see cref="OFXTagAttribute"/> annotation.</param>
    /// <param name="propertyName">Name of the property which the attribute annotation is applied.</param>
    /// <returns>Returns <c>true</c> if the property corresponds a header tag, otherwise returns <c>false</c>.</returns>
    public static bool? IsOFXTagHeader<T>(this T source, string? propertyName = null) {
        var result = GetAttributeInfo<T, OFXTagAttribute>(source, propertyName);

        return result?.IsHeaderTag;
    }
    #endregion
}
*/