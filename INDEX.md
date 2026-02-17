# Índice de Documentación / Documentation Index

## 🔄 ACTUALIZAR LA APLICACIÓN / UPDATE THE APP

**¿Ya tienes la aplicación instalada?** → **[ACTUALIZAR.md](ACTUALIZAR.md)** - Comandos para actualizar y ejecutar la última versión

---

## ⚠️ IMPORTANTE: Descargar la Aplicación Completa

**¿Solo ves el archivo README?** Lee esto primero: **[DESCARGAR_APLICACION.md](DESCARGAR_APLICACION.md)**

La aplicación completa está en la rama `copilot/create-ping-app`. Clónala con:
```bash
git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git
```

---

## 🇪🇸 Documentación en Español

### ¡Primero lo Primero!
- **[ACTUALIZAR.md](ACTUALIZAR.md)** - 🔄 **ACTUALIZAR Y EJECUTAR** - Comandos para todos los sistemas operativos
- **[DESCARGAR_APLICACION.md](DESCARGAR_APLICACION.md)** - 🚨 Cómo obtener la aplicación completa (no solo el README)

### Generación de Ejecutables y Distribución
- **[GENERAR_EJECUTABLES.md](GENERAR_EJECUTABLES.md)** - 📦 **GUÍA COMPLETA** - Cómo generar ejecutables para todas las plataformas

### Para Desarrolladores y Colaboradores
- **[MERGE_COMMANDS.md](MERGE_COMMANDS.md)** - 🔀 **COMANDOS DE MERGE** - Fusionar rama copilot/create-ping-app con main
- **[WIKI_UPLOAD.md](WIKI_UPLOAD.md)** - 📚 **SUBIR AL WIKI** - Cómo subir documentación al Wiki de GitHub

### Para Usuarios de Mac Silicon (M1, M2, M3)
- **[MAC_REQUISITOS_EJECUTABLE_UNICO.md](MAC_REQUISITOS_EJECUTABLE_UNICO.md)** - 🍎 **NUEVO:** Requisitos Mac para generar ejecutable de un solo archivo
- **[MAC_SILICON_BUILD_ALL.md](MAC_SILICON_BUILD_ALL.md)** - 🚀 Obtener última versión y compilar para TODAS las plataformas
- **[COMANDO_MAC_SILICON.md](COMANDO_MAC_SILICON.md)** - 🚀 **COMANDO TODO-EN-UNO** - Última versión con un solo comando
- **[QUICKSTART_MAC_ES.md](QUICKSTART_MAC_ES.md)** - ⚡ Comandos rápidos para instalar y ejecutar
- **[MAC_SILICON_ES.md](MAC_SILICON_ES.md)** - 📖 Guía completa de instalación paso a paso

### Nuevas Características y Correcciones
- **[FEATURES_SCATTER_REPORT.md](FEATURES_SCATTER_REPORT.md)** - 📊 Gráfica de dispersión y generación de reportes
- **[FIXES_GRAFICA_REPORTE.md](FIXES_GRAFICA_REPORTE.md)** - 🔧 Correcciones de visibilidad y formato CSV

## 🇬🇧 English Documentation

### General
- **[README.md](README.md)** - Main documentation, features, and usage
- **[PUBLISHING.md](PUBLISHING.md)** - Publishing instructions for all platforms

### Executable Generation & Distribution
- **[EXECUTABLE_GENERATION.md](EXECUTABLE_GENERATION.md)** - 📦 **COMPLETE GUIDE** - How to generate executables for all platforms

### Technical
- **[ARCHITECTURE.md](ARCHITECTURE.md)** - Technical architecture and design patterns
- **[UI_LAYOUT.md](UI_LAYOUT.md)** - User interface layout and design

## 🚀 Quick Start by Platform

### All Platforms at Once
```bash
# Linux/macOS
./build-all-platforms.sh

# Windows
build-all-platforms.bat
```

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

Ver guía completa: [MAC_SILICON_ES.md](MAC_SILICON_ES.md) | [GENERAR_EJECUTABLES.md](GENERAR_EJECUTABLES.md)

## 📋 Documentation Summary

| File | Language | Purpose | Audience |
|------|----------|---------|----------|
| README.md | English | Main documentation | All users |
| GENERAR_EJECUTABLES.md | Spanish | Executable generation guide | Developers/Distributors |
| EXECUTABLE_GENERATION.md | English | Executable generation guide | Developers/Distributors |
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
