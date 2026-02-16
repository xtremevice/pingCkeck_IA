# Índice de Documentación / Documentation Index

## 🇪🇸 Documentación en Español

### Para Usuarios de Mac Silicon (M1, M2, M3)
- **[QUICKSTART_MAC_ES.md](QUICKSTART_MAC_ES.md)** - ⚡ Comandos rápidos para instalar y ejecutar
- **[MAC_SILICON_ES.md](MAC_SILICON_ES.md)** - 📖 Guía completa de instalación paso a paso

## 🇬🇧 English Documentation

### General
- **[README.md](README.md)** - Main documentation, features, and usage
- **[PUBLISHING.md](PUBLISHING.md)** - Publishing instructions for all platforms

### Technical
- **[ARCHITECTURE.md](ARCHITECTURE.md)** - Technical architecture and design patterns
- **[UI_LAYOUT.md](UI_LAYOUT.md)** - User interface layout and design

## 🚀 Quick Start by Platform

### Windows
```bash
cd PingMonitor
dotnet publish -c Release -r win-x64 --self-contained
cd bin/Release/net8.0/win-x64/publish/
PingMonitor.exe
```

### Linux
```bash
cd PingMonitor
dotnet publish -c Release -r linux-x64 --self-contained
cd bin/Release/net8.0/linux-x64/publish/
chmod +x PingMonitor
./PingMonitor
```

### macOS Intel
```bash
cd PingMonitor
dotnet publish -c Release -r osx-x64 --self-contained
cd bin/Release/net8.0/osx-x64/publish/
chmod +x PingMonitor
./PingMonitor
```

### macOS Apple Silicon (M1/M2/M3)
```bash
cd PingMonitor
dotnet publish -c Release -r osx-arm64 --self-contained
cd bin/Release/net8.0/osx-arm64/publish/
chmod +x PingMonitor
./PingMonitor
```

Ver guía completa: [MAC_SILICON_ES.md](MAC_SILICON_ES.md)

## 📋 Documentation Summary

| File | Language | Purpose | Audience |
|------|----------|---------|----------|
| README.md | English | Main documentation | All users |
| QUICKSTART_MAC_ES.md | Spanish | Quick commands | Mac Silicon users |
| MAC_SILICON_ES.md | Spanish | Complete guide | Mac Silicon users |
| PUBLISHING.md | English | Publishing guide | Developers |
| ARCHITECTURE.md | English | Technical details | Developers |
| UI_LAYOUT.md | English | UI design | Developers/Designers |

## 🆘 Getting Help

### Common Issues
1. **".NET not found"**: Install .NET 8 SDK from https://dotnet.microsoft.com/download/dotnet/8.0
2. **"Developer cannot be verified" (macOS)**: Run `xattr -d com.apple.quarantine PingMonitor`
3. **Build errors**: Make sure you're in the correct directory (`PingMonitor/`)

### Requirements
- .NET 8.0 SDK or higher
- macOS 10.12+ / Windows 7+ / Linux with X11 or Wayland

## 🔗 Links

- Repository: https://github.com/xtremevice/pingCkeck_IA
- .NET Download: https://dotnet.microsoft.com/download/dotnet/8.0
