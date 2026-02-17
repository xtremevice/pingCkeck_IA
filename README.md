# Ping Monitor

A cross-platform desktop application built with C# .NET Core 8 and Avalonia UI for monitoring network connectivity to multiple sites in real-time.

## ⚠️ IMPORTANT: Build Scripts Location

**🚨 Note for users trying to use `build-all-platforms.sh`:**

The build automation scripts (`build-all-platforms.sh` and `build-all-platforms.bat`) are located in the `copilot/discuss-executable-creation` branch, NOT in the main branch.

**If you cloned from main and got "no such file or directory":**

```bash
# Option 1: Switch to the branch with build scripts
cd pingCkeck_IA
git fetch origin copilot/discuss-executable-creation
git checkout copilot/discuss-executable-creation
./build-all-platforms.sh

# Option 2: Clone the correct branch directly
git clone -b copilot/discuss-executable-creation https://github.com/xtremevice/pingCkeck_IA.git
cd pingCkeck_IA
./build-all-platforms.sh
```

**For the application code**, use the `copilot/create-ping-app` branch.

---

## 🔄 ACTUALIZAR / UPDATE

**🇪🇸 ¿Ya tienes la aplicación?** → Ver [ACTUALIZAR.md](ACTUALIZAR.md) para comandos de actualización

**🇬🇧 Already have the app?** → See [ACTUALIZAR.md](ACTUALIZAR.md) for update commands

### Comando Rápido para Actualizar (Mac Silicon)
```bash
cd ~/Desktop/pingCkeck_IA && git pull && cd PingMonitor && dotnet publish -c Release -r osx-arm64 --self-contained && cd bin/Release/net8.0/osx-arm64/publish/ && chmod +x PingMonitor && ./PingMonitor
```

## ⚠️ IMPORTANTE / IMPORTANT

**🇪🇸 ¿Solo ves este README?** → Ver [DESCARGAR_APLICACION.md](DESCARGAR_APLICACION.md) para obtener la aplicación completa.

**🇬🇧 Only seeing this README?** → The full application is in the `copilot/create-ping-app` branch. Clone with:
```bash
git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git
```

## 📚 Documentation

- **[GENERAR_EJECUTABLES.md](GENERAR_EJECUTABLES.md)** - 📦 🇪🇸 **GUÍA COMPLETA: Generar ejecutables para todas las plataformas**
- **[EXECUTABLE_GENERATION.md](EXECUTABLE_GENERATION.md)** - 📦 🇬🇧 **COMPLETE GUIDE: Generate executables for all platforms**
- **[MAC_REQUISITOS_EJECUTABLE_UNICO.md](MAC_REQUISITOS_EJECUTABLE_UNICO.md)** - 🍎 🇪🇸 **Mac: Requisitos para ejecutable de un solo archivo**
- **[MAC_SILICON_BUILD_ALL.md](MAC_SILICON_BUILD_ALL.md)** - 🚀 🇪🇸 **Mac Silicon: Obtener última versión y compilar para TODAS las plataformas**
- **[ACTUALIZAR.md](ACTUALIZAR.md)** - 🔄 **COMANDOS PARA ACTUALIZAR Y EJECUTAR** (Todos los sistemas)
- **[MERGE_COMMANDS.md](MERGE_COMMANDS.md)** - 🔀 **COMANDOS PARA MERGE CON MAIN** (Fusionar ramas)
- **[WIKI_UPLOAD.md](WIKI_UPLOAD.md)** - 📚 **SUBIR DOCUMENTACIÓN AL WIKI** (GitHub Wiki)
- **[INDEX.md](INDEX.md)** - Complete documentation index
- **[COMANDO_MAC_SILICON.md](COMANDO_MAC_SILICON.md)** - 🚀 🇪🇸 **COMANDO RÁPIDO para Mac Silicon - Última Versión**
- **[DESCARGAR_APLICACION.md](DESCARGAR_APLICACION.md)** - 🇪🇸 Guía para descargar la aplicación completa
- **🇪🇸 Para usuarios de Mac Silicon**: Ver [QUICKSTART_MAC_ES.md](QUICKSTART_MAC_ES.md) para comandos rápidos

## Screenshot

The application provides a clean interface with:
- Text box to add new URLs or IP addresses
- Configurable ping interval control
- List view showing each monitored site with:
  - Site URL/IP and online/offline status (green/red)
  - Last ping time in milliseconds
  - Average of last 50 pings
  - Maximum ping time recorded
  - Real-time mini graph showing ping history
  - Remove button for each site

## Features

- **Multi-site monitoring**: Add and monitor multiple URLs or IP addresses simultaneously
- **Real-time statistics**: 
  - Last ping response time (milliseconds)
  - Average of last 50 pings
  - Maximum ping time
  - Visual mini-graph showing ping history
- **Configurable interval**: Adjust ping frequency from 100ms to 10000ms (default: 1000ms)
- **Cross-platform**: Works on Windows, Linux, and macOS

## Requirements

- .NET 8.0 SDK or higher

**For Mac Silicon (Apple M1/M2/M3) users**: See [MAC_SILICON_ES.md](MAC_SILICON_ES.md) for complete installation instructions in Spanish.

## Building the Application

```bash
cd PingMonitor
dotnet build
```

## Running the Application

```bash
cd PingMonitor
dotnet run
```

## Building Executables for Distribution

### Quick Build (All Platforms)

**Windows:**
```cmd
build-all-platforms.bat
```

**Linux/macOS:**
```bash
./build-all-platforms.sh
```

This will generate self-contained executables for Windows, Linux, macOS Intel, and macOS Apple Silicon.

### Complete Guide

- **🇪🇸 Español**: See [GENERAR_EJECUTABLES.md](GENERAR_EJECUTABLES.md) for complete guide on generating executables
- **🇬🇧 English**: See [EXECUTABLE_GENERATION.md](EXECUTABLE_GENERATION.md) for complete guide on generating executables
- **Basic instructions**: See [PUBLISHING.md](PUBLISHING.md) for basic publishing commands

## Usage

1. **Add a site**: Enter a URL (e.g., `google.com`) or IP address (e.g., `8.8.8.8`) in the text box and click "Add Site"
2. **Adjust ping interval**: Change the interval value (in milliseconds) and click "Update Interval" to apply to all sites
3. **Monitor**: Watch real-time ping statistics and graphs for each site
4. **Remove sites**: Click the "Remove" button next to any site to stop monitoring it

### Example Sites to Monitor

You can test the application with these commonly used sites:
- `google.com` - Google's main site
- `8.8.8.8` - Google's public DNS
- `1.1.1.1` - Cloudflare's public DNS
- `github.com` - GitHub
- `cloudflare.com` - Cloudflare
- Your local router (e.g., `192.168.1.1`)

## Features Details

- **Last**: Shows the response time of the most recent ping
- **Avg (50)**: Displays the average response time of the last 50 pings
- **Max**: Shows the maximum response time recorded since monitoring started
- **Graph**: Visual representation of ping history (last 50 pings)
- **Status**: Green text indicates the site is online; red text indicates the site is offline or unreachable

## Platform Compatibility

This application uses Avalonia UI, which provides native support for:
- Windows (7+)
- Linux (with X11 or Wayland)
- macOS (10.12+)

## Architecture

The application follows the MVVM (Model-View-ViewModel) pattern:
- **Models**: `PingSiteModel` - Data model for ping statistics
- **Services**: `PingService` - Background ping execution
- **ViewModels**: `MainWindowViewModel`, `PingSiteViewModel` - UI logic and data binding
- **Views**: `MainWindow.axaml` - User interface
- **Controls**: `MiniPingGraph` - Custom control for visualizing ping history

