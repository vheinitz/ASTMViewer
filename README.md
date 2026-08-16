# ASTMViewer

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

Test program in C# for parsing **ASTM E1394** messages and creating object-trees.

ASTM E1394 (also known as LIS2-A2) is the standard communication protocol used
between laboratory instruments and laboratory information systems (LIS) for
exchanging test orders and results.

## Features

- Parses ASTM 1394 message frames (header `H`, patient `P`, order `O`, result `R`,
  comment `C`, manufacturer `M`, terminator `L`).
- Builds an in-memory object tree representing the parsed records.
- Provides a WinForms GUI (`ASTMParserGUI`) to load and inspect messages.
- Includes a commented, line-by-line parser class suitable as a reference
  implementation for ASTM parsing in .NET.

## Project structure

```
ASTMParser.cs            Core parser (ASTM_Record, ASTM_Comment, ...)
ASTMParserGUI.cs         WinForms viewer
ASTMParser.sc.cs         Additional parser/render helpers
ASTMViewer.sln / .csproj Visual Studio solution
doc/                     Documentation
```

## Requirements

- .NET Framework (Visual Studio-compatible; the project targets classic
  WinForms/.NET Framework).

## Build & run

Open `ASTMViewer.sln` in Visual Studio and build, or use `msbuild`:

```bash
msbuild ASTMViewer.sln /p:Configuration=Release
```

## Usage

Load an ASTM message file or paste a raw ASTM frame into the viewer. The parser
splits the frame into records (`|` delimiter) and fields (`\` delimiter),
creating an object tree that can be inspected field by field.

## License

[MIT](LICENSE) © Valentin Heinitz
