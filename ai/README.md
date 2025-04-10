# OFXSDK

A comprehensive .NET library for parsing and working with OFX (Open Financial Exchange) files.

## Overview

OFXSDK is a modern .NET library designed to parse, validate, and work with OFX (Open Financial Exchange) files. It supports both OFX 1.x (SGML-based) and OFX 2.x (XML-based) formats, providing a clean, strongly-typed object model for financial data.

## Features

- Support for OFX 1.x and 2.x formats
- Clean object model for banking, credit card, and investment data
- Automatic format detection
- Validation capabilities
- Asynchronous API support
- Comprehensive documentation
- Example applications

## Getting Started

### Installation

```bash
dotnet add package OFXSDK
```

### Basic Usage

```csharp
// Create an OFX client
var client = new OFXClient();

// Parse an OFX file
var document = client.ParseFile("statement.ofx");

// Access banking information
if (document.Banking != null)
{
    Console.WriteLine($"Account: {document.Banking.AccountInfo.AccountNumber}");
    Console.WriteLine($"Balance: {document.Banking.Statement.Balance.LedgerBalance}");

    // List transactions
    foreach (var transaction in document.Banking.Statement.Transactions)
    {
        Console.WriteLine($"{transaction.DatePosted}: {transaction.Amount} - {transaction.Name}");
    }
}
```

### Async Usage

```csharp
// Parse asynchronously
var document = await client.ParseFileAsync("statement.ofx");
```

## Project Structure

- **OFXSDK.Core**: Core domain models and interfaces
- **OFXSDK.Parsing**: OFX parsing implementation (OFX 1.x and 2.x)
- **OFXSDK.Validation**: Validation rules and validators
- **OFXSDK**: Main client library that ties everything together

## Examples

Two example applications are included to demonstrate the library usage:

1. **SimpleParser**: A basic command-line application that parses an OFX file and displays summary information
2. **FullFeaturedClient**: A more advanced application with options for batch processing, report generation, and validation

## Supported Data Types

- Banking statements and transactions
- Credit card statements and transactions
- Investment positions and transactions

## License

MIT License

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.