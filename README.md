# OFX SDK
OFX SDK is a .NET 8.0/9.0 implementation of OFX (Open Financial Exchange) file management, such as read, write, parse, import and export to another serializable formats.

# Objective
The goal of the OFX SDK is to create a level of abstraction to deal with OFX files, offering structured tools to hide some of the complexity needed by the defined standard.


## What is OFX - Open Financial Exchange?

From [OFX.net](https://www.ofx.net/):

> Open Financial Exchange is an open standard for client-server systems and cloud based APIs for exchanging financial data, and performing financial transactions between financial institutions, and financial applications. Further, the API allows the exchange to be facilitated either directly or via an intermediary such as data aggregation service providers.
> 
> OFX has been the dominant direct API for banks to provide data to financial applications since 1997. It is actively deployed at over 7,000 financial institutions, and the remaining institutions have easy access to certified OFX servers via all major technology providers and systems integrators. More information can be found at: http://ofx.org.

OFX SDK implements the requests and responses defined in the open standard specifications, so the main focus of this context is the file handling and parsing the results of the received <code>.ofx</code> files from the financial institutions, as well the transformation from the source format to Xml and Json. Custom output formats are possible to extend and implement through available interfaces and abstractions.

The following list shows the supported specification versions and its current implementation state:

| Specification | Availability | Stage |
| --- | --- | --- |
| ![ver102](https://img.shields.io/badge/version-1.0.2-sucess) | ![state102](https://img.shields.io/badge/state-supported-sucess) | ![impl102](https://img.shields.io/badge/development-in%20progress-sucess) |
| ![ver103](https://img.shields.io/badge/version-1.0.3-inactive) | ![state103](https://img.shields.io/badge/state-not%20yet%20supported-inactive) | ![impl103](https://img.shields.io/badge/development-not%20yet%20implemented-inactive) |
| ![ver16](https://img.shields.io/badge/version-1.6-inactive) | ![state16](https://img.shields.io/badge/state-not%20yet%20supported-inactive) | ![impl16](https://img.shields.io/badge/development-not%20yet%20implemented-inactive) |
| ![ver203](https://img.shields.io/badge/version-2.0.3-inactive) | ![state203](https://img.shields.io/badge/state-not%20yet%20supported-inactive) | ![impl203](https://img.shields.io/badge/development-not%20yet%20implemented-inactive) |
| ![ver211](https://img.shields.io/badge/version-2.1.1-inactive) | ![state211](https://img.shields.io/badge/state-not%20yet%20supported-inactive) | ![impl211](https://img.shields.io/badge/development-not%20yet%20implemented-inactive) |
| ![ver22](https://img.shields.io/badge/version-2.2-inactive) | ![state22](https://img.shields.io/badge/state-not%20yet%20supported-inactive) | ![impl22](https://img.shields.io/badge/development-not%20yet%20implemented-inactive) |
| ![ver221](https://img.shields.io/badge/version-2.2.1-inactive) | ![state221](https://img.shields.io/badge/state-not%20yet%20supported-inactive) | ![impl221](https://img.shields.io/badge/development-not%20yet%20implemented-inactive) |
| ![ver23](https://img.shields.io/badge/version-2.3-inactive) | ![state23](https://img.shields.io/badge/state-not%20yet%20supported-inactive) | ![impl23](https://img.shields.io/badge/development-not%20yet%20implemented-inactive) |

# Contributions
**Author**: Eric Roberto Darruiz <code>(GitHub [@edarruiz](https://github.com/edarruiz))</code>

There are no dedicated developers for this project, so development is entirely based on voluntary effort. I am working on this project in my spare time, whenever my work schedule and business projects allow me to do so.

If you are interested on this project, you can contribute as well. 

Here are some guidelines concerning contributions:
- All contributions should be done on <code>contrib</code>.
- <code>main</code> is only for **PR** and stable code roadmap.
- Every pull request should preferably be linked to a GitHub issue.
- Write unit tests, if applicable.
- Don't be afraid to suggest any changes that can help the goal of this SDK. New ideas are always welcome!


# Development Environment
This project has the following minimal requirements to build:
- Visual Studio 2022 Community or higher 
- .NET 8.0 and 9.0
- C# 12.0 for .NET 8.0 - [What is new in C# 12?](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12)
- C# 13.0 for .NET 9.0 - [What is new in C# 13?](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-13)

# Documentation
[Here](/docs/documentation.md) you can find the OFX SDK Documentation.

# Roadmap
[Here](/docs/roadmap.md) you can find the OFX SDK development roadmap
