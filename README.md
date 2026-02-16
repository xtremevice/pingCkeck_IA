# Ping Monitor

A cross-platform desktop application built with C# .NET Core 8 and Avalonia UI for monitoring network connectivity to multiple sites in real-time.

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

## Publishing

See [PUBLISHING.md](PUBLISHING.md) for instructions on how to publish the application for different platforms.

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

