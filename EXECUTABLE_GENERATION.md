# Multi-Platform Executable Generation Guide

This document explains how to generate executables of the PingMonitor application for different platforms and operating systems.

## 📋 Table of Contents

- [What are Executables?](#what-are-executables)
- [Supported Platforms](#supported-platforms)
- [Generation Methods](#generation-methods)
- [Usage Guide](#usage-guide)
- [Executable Distribution](#executable-distribution)
- [FAQ](#faq)

---

## 🎯 What are Executables?

**Executables** are binary files that can be run directly on an operating system without needing to install the .NET SDK. They are "self-contained" versions of the application that include:

- The compiled application code
- The required .NET runtime
- All necessary libraries and dependencies

**Advantages:**
- ✅ No .NET installation required on target machine
- ✅ Independent and portable executables
- ✅ Easy distribution to end users
- ✅ Guaranteed compatibility with specific .NET version

**Disadvantages:**
- ⚠️ Larger file size (includes .NET runtime)
- ⚠️ Platform and architecture-specific executables

---

## 💻 Supported Platforms

The PingMonitor application can generate executables for the following platforms:

| Platform | Runtime ID | Operating System | Architecture |
|----------|-----------|------------------|--------------|
| **Windows** | `win-x64` | Windows 7+ | x64 (64-bit) |
| **Linux** | `linux-x64` | Modern Linux distributions | x64 (64-bit) |
| **macOS Intel** | `osx-x64` | macOS 10.12+ | Intel x64 |
| **macOS Apple Silicon** | `osx-arm64` | macOS 11.0+ | Apple M1/M2/M3 |

---

## 🛠️ Generation Methods

### Method 1: Automated Script (Recommended)

#### On Windows:
```cmd
build-all-platforms.bat
```

#### On Linux/macOS:
```bash
./build-all-platforms.sh
```

This script will automatically compile executables for **all platforms** and place them in:
- `PingMonitor/bin/Release/net8.0/win-x64/publish/`
- `PingMonitor/bin/Release/net8.0/linux-x64/publish/`
- `PingMonitor/bin/Release/net8.0/osx-x64/publish/`
- `PingMonitor/bin/Release/net8.0/osx-arm64/publish/`

### Method 2: Manual Compilation

#### Windows (x64):
```bash
cd PingMonitor
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

#### Linux (x64):
```bash
cd PingMonitor
dotnet publish -c Release -r linux-x64 --self-contained -p:PublishSingleFile=true
```

#### macOS Intel (x64):
```bash
cd PingMonitor
dotnet publish -c Release -r osx-x64 --self-contained -p:PublishSingleFile=true
```

#### macOS Apple Silicon (ARM64):
```bash
cd PingMonitor
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true
```

### Method 3: GitHub Actions (CI/CD Automation)

Executables are generated automatically when:

1. **A version tag is created** (e.g., `v1.0.0`):
   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```

2. **The workflow is manually triggered** from GitHub Actions:
   - Go to the "Actions" tab on GitHub
   - Select "Build Multi-Platform Executables"
   - Click "Run workflow"

The workflow will automatically create:
- Compressed files for each platform
- A GitHub release with all executables
- Downloadable artifacts for 30 days

---

## 📖 Usage Guide

### Prerequisites

1. **.NET 8.0 SDK** installed:
   ```bash
   dotnet --version
   # Should show 8.0.x or higher
   ```

2. **Read/write access** to the project directory

### Generate Executables Locally

1. **Clone the repository** (if you haven't already):
   ```bash
   git clone https://github.com/xtremevice/pingCkeck_IA.git
   cd pingCkeck_IA
   ```

2. **Run the build script**:
   
   On Windows:
   ```cmd
   build-all-platforms.bat
   ```
   
   On Linux/macOS:
   ```bash
   ./build-all-platforms.sh
   ```

3. **Find the executables** in:
   ```
   PingMonitor/bin/Release/net8.0/{runtime-id}/publish/
   ```

### Run an Executable

#### Windows:
```cmd
PingMonitor\bin\Release\net8.0\win-x64\publish\PingMonitor.exe
```

#### Linux:
```bash
cd PingMonitor/bin/Release/net8.0/linux-x64/publish/
chmod +x PingMonitor
./PingMonitor
```

#### macOS:
```bash
cd PingMonitor/bin/Release/net8.0/osx-arm64/publish/
chmod +x PingMonitor
./PingMonitor
```

---

## 📦 Executable Distribution

### Option 1: GitHub Releases (Recommended)

1. Create a version tag:
   ```bash
   git tag -a v1.0.0 -m "Release version 1.0.0"
   git push origin v1.0.0
   ```

2. GitHub Actions will automatically create a release with:
   - `PingMonitor-windows-x64.zip`
   - `PingMonitor-linux-x64.tar.gz`
   - `PingMonitor-macos-intel.tar.gz`
   - `PingMonitor-macos-arm64.tar.gz`

3. Users can download the file for their platform from the "Releases" section

### Option 2: Manual Distribution

1. Generate executables using the script
2. Compress the corresponding `publish/` folder:
   - Windows: Create `.zip` file
   - Linux/macOS: Create `.tar.gz` file
3. Distribute the compressed files to users

### Option 3: Native Installers (Advanced)

To create more professional native installers:

- **Windows**: Use [WiX Toolset](https://wixtoolset.org/) or [Inno Setup](https://jrsoftware.org/isinfo.php)
- **macOS**: Create a `.app` bundle or use [create-dmg](https://github.com/create-dmg/create-dmg)
- **Linux**: Generate `.deb`, `.rpm`, or [AppImage](https://appimage.org/) packages

---

## ❓ FAQ

### Why are the executables so large?

Self-contained executables include the complete .NET runtime (~50-70 MB per platform). If size is a concern, you can:

1. **Use framework-dependent publishing**:
   ```bash
   dotnet publish -c Release -r win-x64
   ```
   This requires .NET to be installed on the target machine but significantly reduces size.

2. **Enable trimming** to reduce size:
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained -p:PublishTrimmed=true
   ```
   ⚠️ Warning: Trimming can cause issues in some applications.

### Can I compile for one platform from another?

Yes, .NET supports **cross-compilation**. For example, you can compile macOS executables from Windows:

```bash
dotnet publish -c Release -r osx-arm64 --self-contained
```

However, you **cannot test** the executable on a different platform.

### What does "self-contained" mean?

"Self-contained" means the executable includes:
- The application code
- The .NET runtime
- All necessary libraries

The user doesn't need to have .NET installed.

### How do I update a distributed executable?

1. **Manual method**: Users download the new version and replace the old executable
2. **Automatic updates**: Implement an auto-update system in the application (requires additional development)
3. **GitHub Releases**: Users can check and download new versions from the Releases page

### Are the executables safe?

Generated executables are as safe as the source code. However:

- ✅ Official GitHub Actions executables are verified
- ⚠️ Users should only download from trusted sources
- 💡 Consider digitally signing executables for enterprise distribution

---

## 🔧 Troubleshooting

### Error: ".NET SDK is not installed"

**Solution**: Install .NET 8.0 SDK from [dotnet.microsoft.com](https://dotnet.microsoft.com/download)

### Error: "Permission denied" on Linux/macOS

**Solution**: Grant execution permissions:
```bash
chmod +x PingMonitor
```

### Executable won't open on macOS

**Solution**: macOS may block unsigned applications. Run:
```bash
xattr -cr PingMonitor
```

Or go to "System Settings" > "Privacy & Security" and allow the application.

---

## 📚 Additional Resources

- [Official .NET Publishing Documentation](https://docs.microsoft.com/en-us/dotnet/core/deploying/)
- [Runtime Identifiers (RID) Catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)
- [PUBLISHING.md](PUBLISHING.md) - Basic publishing instructions
- [GitHub Actions Workflow](.github/workflows/build-release.yml) - CI/CD configuration

---

## 💡 Next Steps

Once you have the executables generated:

1. **Test** each executable on its corresponding platform
2. **Document** any special requirements (permissions, system dependencies)
3. **Create a Release** on GitHub for public distribution
4. **Update the README** with download instructions for end users

---

Have more questions? Open an [Issue on GitHub](https://github.com/xtremevice/pingCkeck_IA/issues) to get help.
