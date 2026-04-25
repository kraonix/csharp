@echo off
echo ========================================
echo   Course Management System Launcher
echo ========================================
echo.

REM Get the directory where the batch file is located
set SCRIPT_DIR=%~dp0

REM Check if node_modules exists in frontend
cd /d "%SCRIPT_DIR%frontend"
if not exist "node_modules\" (
    echo [0/3] Installing frontend dependencies...
    echo This may take a few minutes on first run...
    echo.
    call npm install
    if errorlevel 1 (
        echo.
        echo ERROR: Failed to install dependencies!
        echo Please run 'npm install' manually in the frontend folder.
        pause
        exit /b 1
    )
    echo.
    echo Dependencies installed successfully!
    echo.
)

REM Start the .NET Backend API
echo [1/2] Starting .NET Backend API...
cd /d "%SCRIPT_DIR%CourseManagementWebApi"
start "Course Management API" cmd /k "dotnet run"
echo Backend API starting on https://localhost:5288
echo.

REM Wait a moment for the backend to initialize
timeout /t 3 /nobreak >nul

REM Start the Angular Frontend
echo [2/2] Starting Angular Frontend...
cd /d "%SCRIPT_DIR%frontend"
start "Course Management Frontend" cmd /k "npm start"
echo Frontend starting on http://localhost:4200
echo.

echo ========================================
echo   Both services are starting!
echo ========================================
echo.
echo Backend API: https://localhost:5288
echo Frontend:    http://localhost:4200
echo.
echo Press any key to close this window...
echo (The services will continue running in separate windows)
pause >nul
