namespace OFX.SDK.Primitives.Header;

/// <summary>
/// Represents the OFX character set used for character data.
/// </summary>
public enum OFXCharset {
    /// <summary>
    /// Represents the ISO 8859-1 character set.
    /// </summary>
    [OFXValue<string>("ISO-8859-1")]
    ISO_8859_1 = 0,
    /// <summary>
    /// Represents the Windows-1252 character set.
    /// </summary>
    [OFXValue<string>("1252")]
    WIN_1252,
    /// <summary>
    /// No character set is specified.
    /// </summary>
    [OFXValue<string>("NONE")]
    None
}
