# Publishing Instructions

## Publish for Windows

```bash
cd PingMonitor
dotnet publish -c Release -r win-x64 --self-contained
```

The published application will be in: `bin/Release/net8.0/win-x64/publish/`

## Publish for Linux

```bash
cd PingMonitor
dotnet publish -c Release -r linux-x64 --self-contained
```

The published application will be in: `bin/Release/net8.0/linux-x64/publish/`

## Publish for macOS

```bash
cd PingMonitor
dotnet publish -c Release -r osx-x64 --self-contained
```

The published application will be in: `bin/Release/net8.0/osx-x64/publish/`

## Framework-dependent (smaller size)

If you prefer smaller binaries and .NET 8 is already installed on the target system:

```bash
cd PingMonitor
dotnet publish -c Release -r <runtime-identifier>
```

Where `<runtime-identifier>` is one of: `win-x64`, `linux-x64`, `osx-x64`, `osx-arm64` (for Apple Silicon)

## Running the published application

### Windows
Double-click `PingMonitor.exe` in the publish folder

### Linux/macOS
```bash
chmod +x PingMonitor
./PingMonitor
```
