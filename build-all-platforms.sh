#!/bin/bash

# Build Multi-Platform Executables Script
# This script builds self-contained executables for all supported platforms

set -e

echo "========================================="
echo "PingMonitor - Multi-Platform Build Script"
echo "========================================="
echo ""

# Color codes for output
GREEN='\033[0;32m'
BLUE='\033[0;34m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

# Check if .NET SDK is installed
if ! command -v dotnet &> /dev/null; then
    echo -e "${YELLOW}Error: .NET SDK is not installed. Please install .NET 8.0 SDK or higher.${NC}"
    exit 1
fi

# Display .NET version
echo -e "${BLUE}Using .NET version:${NC}"
dotnet --version
echo ""

# Navigate to PingMonitor directory
cd "$(dirname "$0")/PingMonitor"

# Clean previous builds
echo -e "${BLUE}Cleaning previous builds...${NC}"
dotnet clean -c Release
echo ""

# Build platforms
platforms=(
    "win-x64:Windows (x64)"
    "linux-x64:Linux (x64)"
    "osx-x64:macOS Intel (x64)"
    "osx-arm64:macOS Apple Silicon (ARM64)"
)

echo -e "${BLUE}Building for all platforms...${NC}"
echo ""

for platform_info in "${platforms[@]}"; do
    IFS=':' read -r runtime display_name <<< "$platform_info"
    
    echo -e "${GREEN}Building for ${display_name}...${NC}"
    dotnet publish -c Release -r "$runtime" --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=false
    
    # Set executable permissions for Unix platforms
    if [[ "$runtime" == linux* ]] || [[ "$runtime" == osx* ]]; then
        chmod +x "bin/Release/net8.0/$runtime/publish/PingMonitor"
    fi
    
    echo -e "${GREEN}✓ Build complete: bin/Release/net8.0/$runtime/publish/${NC}"
    echo ""
done

echo ""
echo -e "${GREEN}=========================================${NC}"
echo -e "${GREEN}All builds completed successfully!${NC}"
echo -e "${GREEN}=========================================${NC}"
echo ""
echo "Build outputs:"
for platform_info in "${platforms[@]}"; do
    IFS=':' read -r runtime display_name <<< "$platform_info"
    echo "  - $display_name: PingMonitor/bin/Release/net8.0/$runtime/publish/"
done
echo ""
echo "To run an executable:"
echo "  Windows: bin/Release/net8.0/win-x64/publish/PingMonitor.exe"
echo "  Linux:   bin/Release/net8.0/linux-x64/publish/PingMonitor"
echo "  macOS:   bin/Release/net8.0/osx-{x64|arm64}/publish/PingMonitor"
