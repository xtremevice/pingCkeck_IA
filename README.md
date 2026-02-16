# Ping Monitor

A cross-platform desktop application built with C# .NET Core 8 and Avalonia UI for monitoring network connectivity to multiple sites in real-time.

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

## Usage

1. **Add a site**: Enter a URL (e.g., `google.com`) or IP address (e.g., `8.8.8.8`) in the text box and click "Add Site"
2. **Adjust ping interval**: Change the interval value (in milliseconds) and click "Update Interval" to apply to all sites
3. **Monitor**: Watch real-time ping statistics and graphs for each site
4. **Remove sites**: Click the "Remove" button next to any site to stop monitoring it

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
