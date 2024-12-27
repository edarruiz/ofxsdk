namespace OFX.SDK.Primitives.Header;

/// <summary>
/// Represents the OFX application-level security.
/// </summary>
public enum OFXSecurity {
    /// <summary>
    /// Represents no application-level security.
    /// </summary>
    [OFXValue<string>("NONE")]
    None = 0,
    /// <summary>
    /// Represents Type 1 application-level security.
    /// </summary>
    [OFXValue<string>("TYPE1")]
    Type1
}
