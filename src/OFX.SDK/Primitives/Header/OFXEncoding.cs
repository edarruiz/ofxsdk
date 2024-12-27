namespace OFX.SDK.Primitives.Header;

/// <summary>
/// Represents the OFX text encoding used for character data.
/// </summary>
public enum OFXEncoding {
    /// <summary>
    /// Represents the Unicode text encoding.
    /// </summary>
    [OFXValue<string>("UTF-8")]
    UTF8 = 0,
    /// <summary>
    /// Represents the US ASCII text encoding.
    /// </summary>
    [OFXValue<string>("USASCII")]
    USASCII
}
