using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using OFXSDK.Parsing.Interfaces;
using OFXSDK.Parsing.Parsers;

namespace OFXSDK.Parsing.Factories;

/// <summary>
/// Factory for creating appropriate OFX parser based on content format
/// </summary>
public static class ParserFactory
{
    /// <summary>
    /// Creates an appropriate OFX parser based on examination of the provided content
    /// </summary>
    /// <param name="ofxContent">OFX content as string</param>
    /// <returns>An appropriate parser for the content format</returns>
    public static IOFXParser CreateParser(string ofxContent)
    {
        if (string.IsNullOrWhiteSpace(ofxContent))
        {
            throw new ArgumentException("OFX content cannot be empty", nameof(ofxContent));
        }

        // Check for OFX 2.x format (XML-based)
        if (IsXmlFormat(ofxContent))
        {
            return new OFX2Parser();
        }

        // Default to OFX 1.x parser (SGML-based)
        return new OFX1Parser();
    }

    /// <summary>
    /// Creates an appropriate OFX parser based on examination of the file content
    /// </summary>
    /// <param name="filePath">Path to the OFX file</param>
    /// <returns>An appropriate parser for the file format</returns>
    public static IOFXParser CreateParserFromFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("OFX file not found", filePath);
        }

        // Read just enough of the file to determine the format
        // (first 1KB should contain the header and opening tags)
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        {
            char[] buffer = new char[1024];
            reader.Read(buffer, 0, buffer.Length);
            var content = new string(buffer);
            return CreateParser(content);
        }
    }

    /// <summary>
    /// Creates an appropriate OFX parser based on examination of the stream content
    /// </summary>
    /// <param name="stream">Stream containing OFX data</param>
    /// <returns>An appropriate parser for the content format</returns>
    public static IOFXParser CreateParserFromStream(Stream stream)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        long originalPosition = stream.Position;
        try
        {
            // Read just enough of the stream to determine the format
            // (first 1KB should contain the header and opening tags)
            using (var reader = new StreamReader(stream, Encoding.UTF8, true, 4096, true))
            {
                char[] buffer = new char[1024];
                reader.Read(buffer, 0, buffer.Length);
                var content = new string(buffer);
                return CreateParser(content);
            }
        }
        finally
        {
            // Reset stream position
            stream.Position = originalPosition;
        }
    }

    /// <summary>
    /// Determines if the OFX content is in XML format (OFX 2.x)
    /// </summary>
    private static bool IsXmlFormat(string ofxContent)
    {
        // Look for XML declaration or properly structured XML tags
        if (ofxContent.Contains("<?xml") || 
            ofxContent.Contains("<?XML") ||
            Regex.IsMatch(ofxContent, @"<[^>]+\s+xmlns\s*="))
        {
            return true;
        }

        // Check OFX version in the header
        Match versionMatch = Regex.Match(ofxContent, @"VERSION:(\d+)");
        if (versionMatch.Success)
        {
            string version = versionMatch.Groups[1].Value;
            if (int.TryParse(version, out int versionNumber) && versionNumber >= 200)
            {
                return true;
            }
        }

        // Look for explicitly closed tags, which would indicate XML format
        if (Regex.IsMatch(ofxContent, @"<[^>/]+>[^<]*</[^>]+>"))
        {
            return true;
        }

        return false;
    }
}