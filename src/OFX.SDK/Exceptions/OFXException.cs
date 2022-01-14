using System.Runtime.Serialization;

namespace OFX.SDK.Exceptions;

/// <summary>
/// Represents errors that occur during OFX file handling.
/// </summary>
[Serializable]
public class OFXException : Exception {
    #region Ctor
    /// <summary>
    /// Initializes a new instance of the <see cref="OFXException"/> class.
    /// </summary>
    public OFXException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="OFXException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public OFXException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="OFXException"/> class with a specified error message and a reference to 
    /// the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="inner">The exception that is the cause of the current exception, or a null reference 
    /// if no inner exception is specified.</param>
    public OFXException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="OFXException"/> class with serialized data.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
    /// <exception cref="ArgumentNullException"><c>info</c> is <c>null</c>.</exception>
    /// <exception cref="SerializationException">The class name is <c>null</c> or <see href="https://docs.microsoft.com/en-us/dotnet/api/system.exception.hresult?view=net-6.0#system-exception-hresult">HResult</see> is zero (0).</exception>
    protected OFXException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    #endregion
}
