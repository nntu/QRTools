# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

QRTools is a .NET 9.0 Windows Forms application written in C#. It's a simple QR code-related utility with a minimal implementation.

## Architecture

- **Entry Point**: `Program.cs` contains the Main method and application initialization
- **Main Form**: `Form1.cs` is the primary (and only) form in the application
- **UI Design**: `Form1.Designer.cs` contains the auto-generated Windows Forms designer code
- **Project Type**: Windows Executable (WinExe) using Windows Forms UI framework

## Development Commands

### Build
```bash
dotnet build QRTools.csproj
```

### Build specific configuration
```bash
# Debug build
dotnet build QRTools.csproj -c Debug

# Release build
dotnet build QRTools.csproj -c Release
```

### Run
```bash
dotnet run --project QRTools.csproj
```

### Build from solution
```bash
dotnet build QRTools.sln
```

### Run from solution
```bash
dotnet run --project QRTools.sln
```

## Development Notes

- This is a minimal Windows Forms application targeting .NET 9.0-windows
- The application uses nullable reference types and implicit usings
- Currently contains only a basic empty form with default 800x450 dimensions
- Visual Studio 17+ is recommended for development, but .NET CLI works as well