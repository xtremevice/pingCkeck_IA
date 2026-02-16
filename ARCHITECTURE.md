# Project Structure and Implementation Details

## Overview
This is a cross-platform ping monitoring application built with C# .NET Core 8 and Avalonia UI framework.

## Project Structure

```
pingCkeck_IA/
├── README.md                           # Main documentation
├── PUBLISHING.md                       # Publishing instructions for different platforms
├── .gitignore                          # Git ignore file for .NET projects
├── PingMonitor/                        # Main application project
│   ├── PingMonitor.csproj             # Project file
│   ├── Program.cs                      # Application entry point
│   ├── App.axaml                       # Application definition (XAML)
│   ├── App.axaml.cs                    # Application code-behind
│   ├── ViewLocator.cs                  # View locator for MVVM
│   ├── app.manifest                    # Application manifest
│   ├── Assets/                         # Application assets (icons, etc.)
│   ├── Models/
│   │   └── PingSiteModel.cs           # Data model for ping statistics
│   ├── Services/
│   │   └── PingService.cs             # Background ping service
│   ├── ViewModels/
│   │   ├── ViewModelBase.cs           # Base class for view models
│   │   ├── MainWindowViewModel.cs     # Main window view model
│   │   └── PingSiteViewModel.cs       # Individual site view model
│   ├── Views/
│   │   ├── MainWindow.axaml           # Main window UI (XAML)
│   │   └── MainWindow.axaml.cs        # Main window code-behind
│   ├── Controls/
│   │   └── MiniPingGraph.cs           # Custom control for ping graph
│   └── Converters/
│       └── OnlineStatusToBrushConverter.cs  # Status to color converter
└── PingMonitor.Tests/                  # Unit tests project
    ├── PingMonitor.Tests.csproj       # Test project file
    └── UnitTest1.cs                    # Unit tests for PingSiteModel

```

## Key Components

### 1. Models (PingSiteModel.cs)
- Stores ping statistics for a single site
- Maintains queue of last 50 ping results
- Calculates average, tracks maximum
- Properties: Url, LastPingMs, MaxPingMs, AveragePing50, IsOnline

### 2. Services (PingService.cs)
- Handles background ping operations
- Uses async/await pattern for non-blocking pings
- Configurable ping interval
- Proper cancellation token handling
- Event-based result notification

### 3. ViewModels

#### MainWindowViewModel
- Manages collection of PingSiteViewModel instances
- Commands: AddSite, RemoveSite, UpdateInterval
- Properties: Sites (ObservableCollection), NewSiteUrl, PingInterval
- Handles cleanup on application close

#### PingSiteViewModel
- Wraps PingSiteModel with UI-friendly properties
- Uses CommunityToolkit.Mvvm for ObservableProperty
- Updates UI on ping results (dispatched to UI thread)
- Manages individual PingService instance

### 4. Views (MainWindow.axaml)
- Clean, modern UI layout
- Input controls for adding sites and configuring interval
- List display with ItemsControl
- Data binding to ViewModels
- Visual feedback with colors and graphs

### 5. Custom Controls (MiniPingGraph.cs)
- Custom Avalonia control for rendering ping history
- Renders line graph with filled area
- Auto-scales based on data range
- Updates when DataPoints property changes

### 6. Converters (OnlineStatusToBrushConverter.cs)
- Converts boolean IsOnline to color brush
- Green for online, Red for offline

## Technologies Used

- **.NET 8.0**: Target framework
- **Avalonia UI 11.3.12**: Cross-platform UI framework
- **CommunityToolkit.Mvvm 8.2.1**: MVVM helpers
- **xUnit**: Unit testing framework
- **System.Net.NetworkInformation**: Ping functionality

## Design Patterns

1. **MVVM (Model-View-ViewModel)**: Separation of concerns
2. **Observer Pattern**: Event-based ping result notification
3. **Command Pattern**: UI commands using RelayCommand
4. **Async/Await**: Asynchronous operations

## Cross-Platform Compatibility

The application works on:
- **Windows**: 7 and later
- **Linux**: X11 or Wayland desktop environments
- **macOS**: 10.12 (Sierra) and later

Avalonia UI provides the cross-platform abstraction layer, allowing the same codebase to run on all platforms without modifications.

## Build and Run

### Development
```bash
cd PingMonitor
dotnet run
```

### Release Build
```bash
cd PingMonitor
dotnet build -c Release
```

### Run Tests
```bash
cd PingMonitor.Tests
dotnet test
```

### Publish (Self-Contained)
```bash
cd PingMonitor
dotnet publish -c Release -r <runtime-id> --self-contained
```

Where `<runtime-id>` is:
- `win-x64` for Windows 64-bit
- `linux-x64` for Linux 64-bit
- `osx-x64` for macOS Intel
- `osx-arm64` for macOS Apple Silicon

## Performance Considerations

- Ping operations run in background tasks
- UI updates dispatched to UI thread
- Efficient data structures (Queue for history)
- Proper resource cleanup (cancellation tokens, dispose)
- No memory leaks (bounded queue size of 50)

## Future Enhancements (Not Implemented)

Potential improvements:
- Save/load site list to file
- Export statistics to CSV
- Notification on site down/up
- Pause/resume monitoring
- Different graph types
- Configurable history size
- Sound alerts
- System tray integration
