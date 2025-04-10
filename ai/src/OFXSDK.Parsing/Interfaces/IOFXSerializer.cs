using System;
using System.IO;
using System.Threading.Tasks;
using OFXSDK.Core.Models;

namespace OFXSDK.Parsing.Interfaces;

/// <summary>
/// Interface for serializing OFXDocument objects to OFX format
/// </summary>
public interface IOFXSerializer
{
    /// <summary>
    /// Serialize an OFXDocument to a string
    /// </summary>
    /// <param name="document">The OFXDocument to serialize</param>
    /// <returns>Serialized OFX data string</returns>
    string Serialize(OFXDocument document);
    
    /// <summary>
    /// Serialize an OFXDocument to a file
    /// </summary>
    /// <param name="document">The OFXDocument to serialize</param>
    /// <param name="filePath">File path where to save the OFX data</param>
    void SerializeToFile(OFXDocument document, string filePath);
    
    /// <summary>
    /// Serialize an OFXDocument to a stream
    /// </summary>
    /// <param name="document">The OFXDocument to serialize</param>
    /// <param name="stream">Stream where to write the OFX data</param>
    void Serialize(OFXDocument document, Stream stream);
    
    /// <summary>
    /// Asynchronously serialize an OFXDocument to a file
    /// </summary>
    /// <param name="document">The OFXDocument to serialize</param>
    /// <param name="filePath">File path where to save the OFX data</param>
    Task SerializeToFileAsync(OFXDocument document, string filePath);
    
    /// <summary>
    /// Asynchronously serialize an OFXDocument to a stream
    /// </summary>
    /// <param name="document">The OFXDocument to serialize</param>
    /// <param name="stream">Stream where to write the OFX data</param>
    Task SerializeAsync(OFXDocument document, Stream stream);
}