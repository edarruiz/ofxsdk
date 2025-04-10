using System;
using System.IO;
using System.Threading.Tasks;
using OFXSDK.Core.Models;

namespace OFXSDK.Parsing.Interfaces;

/// <summary>
/// Interface for OFX format parsers
/// </summary>
public interface IOFXParser
{
    /// <summary>
    /// Parse OFX data from a string
    /// </summary>
    /// <param name="ofxData">OFX data as string</param>
    /// <returns>Parsed OFX document</returns>
    OFXDocument Parse(string ofxData);

    /// <summary>
    /// Parse OFX data from a file
    /// </summary>
    /// <param name="filePath">Path to OFX file</param>
    /// <returns>Parsed OFX document</returns>
    OFXDocument ParseFile(string filePath);

    /// <summary>
    /// Parse OFX data from a stream
    /// </summary>
    /// <param name="stream">Stream containing OFX data</param>
    /// <returns>Parsed OFX document</returns>
    OFXDocument Parse(Stream stream);

    /// <summary>
    /// Asynchronously parse OFX data from a file
    /// </summary>
    /// <param name="filePath">Path to OFX file</param>
    /// <returns>Task containing parsed OFX document</returns>
    Task<OFXDocument> ParseFileAsync(string filePath);

    /// <summary>
    /// Asynchronously parse OFX data from a stream
    /// </summary>
    /// <param name="stream">Stream containing OFX data</param>
    /// <returns>Task containing parsed OFX document</returns>
    Task<OFXDocument> ParseAsync(Stream stream);
}