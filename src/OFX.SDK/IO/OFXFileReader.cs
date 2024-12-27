using System.Text;

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
/// Represents a reader for OFX files.
/// </summary>
public sealed class OFXFileReader {
    #region Fields
    /// <summary>
    /// Represents the known headers of an OFX file.
    /// </summary>
    private IDictionary<string, string> Headers = new Dictionary<string, string> {
        { OFXConstants.Header.TagNames.OFXHEADER, string.Empty },
        { OFXConstants.Header.TagNames.DATA, string.Empty },
        { OFXConstants.Header.TagNames.VERSION, string.Empty },
        { OFXConstants.Header.TagNames.SECURITY, string.Empty },
        { OFXConstants.Header.TagNames.ENCODING, string.Empty },
        { OFXConstants.Header.TagNames.CHARSET, string.Empty },
        { OFXConstants.Header.TagNames.COMPRESSION, string.Empty },
        { OFXConstants.Header.TagNames.OLDFILEUID, string.Empty },
        { OFXConstants.Header.TagNames.NEWFILEUID, string.Empty }
    };

    /// <summary>
    /// Represents an open SGML tag indicator for the SGML map.
    /// </summary>
    private const string OPEN_TAG = "OPEN_TAG";

    /// <summary>
    /// Represents a closed SGML tag indicator for the SGML map.
    /// </summary>
    private const string CLOSE_TAG = "CLOSE_TAG";
    #endregion

    #region Ctor
    /// <summary>
    /// Initializes a new instance of the <see cref="OFXFileReader"/> class with the specified source file path.
    /// </summary>
    /// <param name="sourceFilePath">The path to the OFX file to be read.</param>
    /// <exception cref="ArgumentException">When the <paramref name="sourceFilePath"/> is <see langword="null"/>, empty, 
    /// or consists only of white-space characters.</exception>
    /// <exception cref="FileNotFoundException">When the file specified by <paramref name="sourceFilePath"/> does not exist.</exception>
    public OFXFileReader(string sourceFilePath) {
        ArgumentException.ThrowIfNullOrWhiteSpace(sourceFilePath, nameof(sourceFilePath));

        if (!File.Exists(sourceFilePath)) {
            throw new FileNotFoundException($"The file '{sourceFilePath}' does not exist.");
        }

        FilePath = sourceFilePath;
        ReadFile();
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the file path of the OFX file.
    /// </summary>
    public string FilePath { get; init; } = string.Empty;

    /// <summary>
    /// Gets the SGML tag map of the OFX file.
    /// </summary>
    private IList<SGMLTag> SGMLMap { get; } = [];
    #endregion

    #region Methods
    /// <summary>
    /// Read the OFX file contents and map the SGML tags.
    /// </summary>
    private void ReadFile() {
        ReadOnlySpan<char> line = [];
        int tagLevel = 0;
        bool inBodySection = false;

        using StreamReader reader = new(FilePath);
        while ((line = reader.ReadLine().AsSpan().Trim()) != ReadOnlySpan<char>.Empty) {

            if (line.StartsWith("<OFX>")) {
                inBodySection = true;
            }

            // Headers
            if (!inBodySection && line.Contains(':')) {
                var separatorIndex = line.IndexOf(':');
                Headers[line[..separatorIndex].ToString()] = line[(separatorIndex + 1)..].ToString();
            }

            // Opened tag
            if (inBodySection && line.StartsWith("<") && !line.StartsWith("</") && line.EndsWith(">")) {
                tagLevel++;
                SGMLMap.Add(new() {
                    Name = line[1..^1].ToString(),
                    Value = OPEN_TAG,
                    Level = tagLevel
                });
            }

            // Closed tags
            if (inBodySection && line.StartsWith("</") && line.EndsWith(">")) {
                SGMLMap.Add(new() {
                    Name = line[2..^1].ToString(),
                    Value = CLOSE_TAG,
                    Level = tagLevel
                });
                tagLevel--;
            }

            // tag value
            if (inBodySection && line.StartsWith("<") && !line.StartsWith("</") && !line.EndsWith(">")) {
                var separatorIndex = line.IndexOf('>');
                SGMLMap.Add(new() {
                    Name = line[1..separatorIndex].ToString(),
                    Value = line[(separatorIndex + 1)..].ToString(),
                    Level = tagLevel + 1
                });
            }
        }
    }

    /// <summary>
    /// Converts the OFX file to an XML formatted string.
    /// </summary>
    /// <returns>A <see cref="ReadOnlySpan{T}"/> of characters representing the XML formatted string.</returns>
    public ReadOnlySpan<char> ToXml() {
        StringBuilder xml = new();

        xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
        int level = 0;
        foreach (var tag in SGMLMap) {
            if (tag.Value == "OPEN_TAG") {
                xml.Append($"{new string(' ', level * 2)}<{tag.Name}>\n");
                level++;
            } else if (tag.Value == "CLOSE_TAG") {
                level--;
                xml.Append($"{new string(' ', level * 2)}</{tag.Name}>\n");
            } else {
                xml.Append($"{new string(' ', level * 2)}<{tag.Name}>{tag.Value}</{tag.Name}>\n");
            }
        }

        return xml.ToString().AsSpan();
    }
    #endregion
}
