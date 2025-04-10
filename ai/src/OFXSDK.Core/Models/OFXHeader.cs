namespace OFXSDK.Core.Models;

/// <summary>
/// Represents the OFX file header information
/// </summary>
public class OFXHeader {
    /// <summary>
    /// Gets or sets the OFX header version (e.g., "100")
    /// </summary>
    public string? Version { get; set; } = "100";

    /// <summary>
    /// Gets or sets the data format type (e.g., "OFXSGML")
    /// </summary>
    public string? DataType { get; set; } = "OFXSGML";

    /// <summary>
    /// Gets or sets the format version (e.g., "102")
    /// </summary>
    public string? FormatVersion { get; set; } = "102";

    /// <summary>
    /// Gets or sets the security type (e.g., "NONE")
    /// </summary>
    public string? Security { get; set; } = "NONE";

    /// <summary>
    /// Gets or sets the encoding type (e.g., "USASCII")
    /// </summary>
    public string? Encoding { get; set; } = "USASCII";

    /// <summary>
    /// Gets or sets the character set (e.g., "1252")
    /// </summary>
    public string? Charset { get; set; } = "1252";

    /// <summary>
    /// Gets or sets the compression type (e.g., "NONE")
    /// </summary>
    public string? Compression { get; set; } = "NONE";

    /// <summary>
    /// Gets or sets the old file UID for incremental updates
    /// </summary>
    public string? OldFileUid { get; set; }

    /// <summary>
    /// Gets or sets the new file UID for incremental updates
    /// </summary>
    public string? NewFileUid { get; set; }
}