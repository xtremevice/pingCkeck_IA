@echo off
REM Stub script for main branch
REM This script provides helpful guidance when users clone from main branch

echo ================================================================================
echo           ERROR: Build scripts not available in this branch
echo ================================================================================
echo.
echo The build automation scripts are located in a different branch.
echo.
echo To use the build scripts, you have two options:
echo.
echo ================================================================================
echo Option 1: Switch to the correct branch (if you already cloned)
echo ================================================================================
echo.
echo   git fetch origin copilot/discuss-executable-creation
echo   git checkout copilot/discuss-executable-creation
echo   build-all-platforms.bat
echo.
echo ================================================================================
echo Option 2: Clone the correct branch directly (fresh start)
echo ================================================================================
echo.
echo   git clone -b copilot/discuss-executable-creation https://github.com/xtremevice/pingCkeck_IA.git
echo   cd pingCkeck_IA
echo   build-all-platforms.bat
echo.
echo ================================================================================
echo For more information, see:
echo ================================================================================
echo.
echo   README.md - Main documentation
echo   MAC_SILICON_BUILD_ALL.md - Complete build guide (if available)
echo.
echo ================================================================================
echo.

exit /b 1
