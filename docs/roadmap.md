# OFX SDK Roadmap

This roadmap describes all work done since the start of the project.
The project development was started at 14/jan/2022.

![v1.0.0-alpha-4](https://img.shields.io/badge/version-1.0.0--Alpha--4-success)

- Add support for package source mapping

![v1.0.0-alpha-3](https://img.shields.io/badge/version-1.0.0--Alpha--3-inactive)

- Change namespaces to EDarruiz.OFX.SDK
- Change namespaces to EDarruiz.OFX.SDK.Tests

![v1.0.0-alpha-2](https://img.shields.io/badge/version-1.0.0--Alpha--1-inactive)

- Fix package license and description
- Add unit tests for OFX headers
- Add unit tests for OFX SGML parser
- Refactor OFX Header abstractions and primitives
- Add EDarruiz prefix to package names to be able to publish to NuGet

![v1.0.0-alpha-1](https://img.shields.io/badge/version-1.0.0--Alpha--1-inactive)

- Add support to .NET 9.0
- Removed old project structure (from 2022, .NET 5.0, .NET 6.0)
- Created Parser to read and convert SGML to XML
- Generate classes from OFX 2.3 XSD specification file (optimized for .NET)
- Refactored OFX Header abstractions and primitives
- Removed OFX prefix from all classes

![v0.0.1](https://img.shields.io/badge/version-0.0.1-inactive)

- Repository created
- Development started
- Added initial contents do README.md
- Added specification documentation on `specifications` folder
- Added unit tests project
- Added structure interfaces to base structure composition
- `OFX specification, Version 1.0.2`
  - Added HEADERS structure
  - Added SIGNON message set and message aggregates