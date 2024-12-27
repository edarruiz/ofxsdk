using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Xml;

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


namespace OFXConverter;
internal class OFXFileReader {
    #region Fields
    private static readonly string[] KnownHeaders = [
        "OFXHEADER",
        "DATA",
        "VERSION",
        "SECURITY",
        "ENCODING",
        "CHARSET",
        "COMPRESSION",
        "OLDFILEUID",
        "NEWFILEUID"
    ];
    private static readonly JsonSerializerOptions jsonSerializerOptions = new() {
        WriteIndented = true
    };
    #endregion

    #region Ctor
    public OFXFileReader(string filePath) {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));
        if (!File.Exists(filePath)) {
            throw new FileNotFoundException($"The file '{filePath}' does not exist.");
        }

        FilePath = filePath;
    }
    #endregion

    #region Properties
    public string FilePath { get; init; } = string.Empty;
    public IDictionary<string, string> Headers { get; } = KnownHeaders.ToDictionary(headerKey => headerKey, headerValue => string.Empty);
    public IList<SGMLTag> SGMLMap { get; } = [];
    #endregion

    #region Methods
    public string ToXml() {
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
        return xml.ToString();
    }

    public void ToXmlFile(string filePath) => File.WriteAllText(filePath, ToXml());

    public void ToJsonFile(string filePath) => File.WriteAllText(filePath, JsonSerializer.Serialize(SGMLMap, jsonSerializerOptions));



    public string ToJson() {
        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(ToXml());

        var jsonString = ConvertXmlNodeToJson(xmlDocument!);
        return jsonString;
    }

    private static string ConvertXmlNodeToJson(XmlNode node) {
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });

        WriteJson(writer, node);
        writer.Flush();

        return Encoding.UTF8.GetString(stream.ToArray());
    }

    private static void WriteJson(Utf8JsonWriter writer, XmlNode node) {
        if (node is XmlElement element) {
            writer.WriteStartObject();

            foreach (XmlAttribute attribute in element.Attributes) {
                writer.WriteString($"@{attribute.Name}", attribute.Value);
            }

            foreach (XmlNode child in element.ChildNodes) {
                if (child is XmlText text) {
                    writer.WriteString("value", text.Value);
                } else {
                    writer.WritePropertyName(child.Name);
                    WriteJson(writer, child);
                }
            }

            writer.WriteEndObject();
        } else if (node is XmlText textNode) {
            writer.WriteStringValue(textNode.Value);
        } else if (node is XmlDocument doc) {
            foreach (XmlNode child in doc.ChildNodes) {
                WriteJson(writer, child);
            }
        }
    }




    public void ReadFile() {
        ReadOnlySpan<char> line = [];
        int tagLevel = 0;
        bool inBodySection = false;

        using StreamReader reader = new(FilePath);
        while ((line = reader.ReadLine().AsSpan().Trim()) != ReadOnlySpan<char>.Empty) {

            if (line.StartsWith("<OFX>")) {
                inBodySection = true;
            }

            // headers
            if (!inBodySection && line.Contains(':')) {
                var separatorIndex = line.IndexOf(':');
                Headers[line[..separatorIndex].ToString()] = line[(separatorIndex + 1)..].ToString();
            }

            // open tag
            if (inBodySection && line.StartsWith('<') && !line.StartsWith("</") && line.EndsWith('>')) {
                tagLevel++;
                SGMLMap.Add(new() {
                    Name = line[1..^1].ToString(),
                    Value = "OPEN_TAG",
                    Level = tagLevel
                });
            }

            // close tag
            if (inBodySection && line.StartsWith("</") && line.EndsWith('>')) {
                SGMLMap.Add(new() {
                    Name = line[2..^1].ToString(),
                    Value = "CLOSE_TAG",
                    Level = tagLevel
                });
                tagLevel--;
            }

            // tag value
            if (inBodySection && line.StartsWith('<') && !line.StartsWith("</") && !line.EndsWith('>')) {
                var separatorIndex = line.IndexOf('>');
                SGMLMap.Add(new() {
                    Name = line[1..separatorIndex].ToString(),
                    Value = line[(separatorIndex + 1)..].ToString(),
                    Level = tagLevel + 1
                });
            }
        }
    }
    #endregion
}

[DebuggerDisplay("Name = {Name}, Value = {Value}, Level = {Level}")]
internal struct SGMLTag {
    public string Name { get; set; }
    public string Value { get; set; }
    public int Level { get; set; }
}
