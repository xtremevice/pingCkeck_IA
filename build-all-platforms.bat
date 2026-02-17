@echo off
REM Build Multi-Platform Executables Script for Windows
REM This script builds self-contained executables for all supported platforms

echo =========================================
echo PingMonitor - Multi-Platform Build Script
echo =========================================
echo.

REM Check if .NET SDK is installed
dotnet --version >nul 2>&1
if errorlevel 1 (
    echo Error: .NET SDK is not installed. Please install .NET 8.0 SDK or higher.
    exit /b 1
)

REM Display .NET version
echo Using .NET version:
dotnet --version
echo.

REM Navigate to PingMonitor directory
cd /d "%~dp0PingMonitor"

REM Clean previous builds
echo Cleaning previous builds...
dotnet clean -c Release
echo.

echo Building for all platforms...
echo.

REM Build for Windows x64
echo [1/4] Building for Windows (x64)...
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=false
if errorlevel 1 (
    echo Error building for Windows x64
    exit /b 1
)
echo √ Build complete: bin\Release\net8.0\win-x64\publish\
echo.

REM Build for Linux x64
echo [2/4] Building for Linux (x64)...
dotnet publish -c Release -r linux-x64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=false
if errorlevel 1 (
    echo Error building for Linux x64
    exit /b 1
)
echo √ Build complete: bin\Release\net8.0\linux-x64\publish\
echo.

REM Build for macOS Intel
echo [3/4] Building for macOS Intel (x64)...
dotnet publish -c Release -r osx-x64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=false
if errorlevel 1 (
    echo Error building for macOS Intel
    exit /b 1
)
echo √ Build complete: bin\Release\net8.0\osx-x64\publish\
echo.

REM Build for macOS Apple Silicon
echo [4/4] Building for macOS Apple Silicon (ARM64)...
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=false
if errorlevel 1 (
    echo Error building for macOS ARM64
    exit /b 1
)
echo √ Build complete: bin\Release\net8.0\osx-arm64\publish\
echo.

echo.
echo =========================================
echo All builds completed successfully!
echo =========================================
echo.
echo Build outputs:
echo   - Windows (x64):              PingMonitor\bin\Release\net8.0\win-x64\publish\
echo   - Linux (x64):                PingMonitor\bin\Release\net8.0\linux-x64\publish\
echo   - macOS Intel (x64):          PingMonitor\bin\Release\net8.0\osx-x64\publish\
echo   - macOS Apple Silicon (ARM64): PingMonitor\bin\Release\net8.0\osx-arm64\publish\
echo.
echo To run an executable:
echo   Windows: bin\Release\net8.0\win-x64\publish\PingMonitor.exe
echo   Linux:   bin/Release/net8.0/linux-x64/publish/PingMonitor
echo   macOS:   bin/Release/net8.0/osx-{x64^|arm64}/publish/PingMonitor
echo.
pause
