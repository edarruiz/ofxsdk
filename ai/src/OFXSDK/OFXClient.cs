using OFXSDK.Core.Models;
using OFXSDK.Parsing.Factories;
using OFXSDK.Validation.Interfaces;
using OFXSDK.Validation.Validators;

namespace OFXSDK;

/// <summary>
/// Main client class for OFX SDK providing simplified access to OFX functionality
/// </summary>
public class OFXClient {
    private readonly IOFXValidator _validator;

    /// <summary>
    /// Initializes a new instance of the OFXClient class with default validator
    /// </summary>
    public OFXClient() : this(new BasicOFXValidator()) {
    }

    /// <summary>
    /// Initializes a new instance of the OFXClient class with the specified validator
    /// </summary>
    /// <param name="validator">Validator to use for OFX document validation</param>
    public OFXClient(IOFXValidator validator) {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    /// <summary>
    /// Parse OFX data from a string
    /// </summary>
    /// <param name="ofxData">OFX data as a string</param>
    /// <param name="validate">Whether to validate the OFX document after parsing</param>
    /// <returns>Parsed OFX document</returns>
    public OFXDocument Parse(string ofxData, bool validate = true) {
        if (string.IsNullOrWhiteSpace(ofxData)) {
            throw new ArgumentException("OFX data cannot be null or empty", nameof(ofxData));
        }

        var parser = ParserFactory.CreateParser(ofxData);
        var document = parser.Parse(ofxData);

        if (validate) {
            var validationResult = _validator.Validate(document);
            if (!validationResult.IsValid) {
                throw new InvalidOperationException($"OFX document validation failed: {validationResult.ErrorMessage}");
            }
        }

        return document;
    }

    /// <summary>
    /// Parse OFX data from a file
    /// </summary>
    /// <param name="filePath">Path to the OFX file</param>
    /// <param name="validate">Whether to validate the OFX document after parsing</param>
    /// <returns>Parsed OFX document</returns>
    public OFXDocument ParseFile(string filePath, bool validate = true) {
        if (string.IsNullOrEmpty(filePath)) {
            throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
        }

        if (!File.Exists(filePath)) {
            throw new FileNotFoundException("OFX file not found", filePath);
        }

        var parser = ParserFactory.CreateParserFromFile(filePath);
        var document = parser.ParseFile(filePath);

        if (validate) {
            var validationResult = _validator.Validate(document);
            if (!validationResult.IsValid) {
                throw new InvalidOperationException($"OFX document validation failed: {validationResult.ErrorMessage}");
            }
        }

        return document;
    }

    /// <summary>
    /// Parse OFX data from a stream
    /// </summary>
    /// <param name="stream">Stream containing OFX data</param>
    /// <param name="validate">Whether to validate the OFX document after parsing</param>
    /// <returns>Parsed OFX document</returns>
    public OFXDocument Parse(Stream stream, bool validate = true) {
        ArgumentNullException.ThrowIfNull(stream);

        var parser = ParserFactory.CreateParserFromStream(stream);
        var document = parser.Parse(stream);

        if (validate) {
            var validationResult = _validator.Validate(document);
            if (!validationResult.IsValid) {
                throw new InvalidOperationException($"OFX document validation failed: {validationResult.ErrorMessage}");
            }
        }

        return document;
    }

    /// <summary>
    /// Asynchronously parse OFX data from a file
    /// </summary>
    /// <param name="filePath">Path to the OFX file</param>
    /// <param name="validate">Whether to validate the OFX document after parsing</param>
    /// <returns>Task containing parsed OFX document</returns>
    public async Task<OFXDocument> ParseFileAsync(string? filePath, bool validate = true) {
        if (string.IsNullOrEmpty(filePath)) {
            throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
        }

        if (!File.Exists(filePath)) {
            throw new FileNotFoundException("OFX file not found", filePath);
        }

        var parser = ParserFactory.CreateParserFromFile(filePath);
        var document = await parser.ParseFileAsync(filePath);

        if (validate) {
            var validationResult = await _validator.ValidateAsync(document);
            if (!validationResult.IsValid) {
                throw new InvalidOperationException($"OFX document validation failed: {validationResult.ErrorMessage}");
            }
        }

        return document;
    }

    /// <summary>
    /// Asynchronously parse OFX data from a stream
    /// </summary>
    /// <param name="stream">Stream containing OFX data</param>
    /// <param name="validate">Whether to validate the OFX document after parsing</param>
    /// <returns>Task containing parsed OFX document</returns>
    public async Task<OFXDocument> ParseAsync(Stream stream, bool validate = true) {
        ArgumentNullException.ThrowIfNull(stream);

        var parser = ParserFactory.CreateParserFromStream(stream);
        var document = await parser.ParseAsync(stream);

        if (validate) {
            var validationResult = await _validator.ValidateAsync(document);
            if (!validationResult.IsValid) {
                throw new InvalidOperationException($"OFX document validation failed: {validationResult.ErrorMessage}");
            }
        }

        return document;
    }
}