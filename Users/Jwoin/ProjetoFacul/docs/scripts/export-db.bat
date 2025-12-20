@echo off
REM Copy app.db to docs/artifacts with timestamp
set TIMESTAMP=%DATE:~10,4%-%DATE:~4,2%-%DATE:~7,2%_%TIME:~0,2%-%TIME:~3,2%-%TIME:~6,2%
set TIMESTAMP=%TIMESTAMP: =0%
if not exist "%~dp0artifacts" mkdir "%~dp0artifacts"
copy "%~dp0..\app.db" "%~dp0artifacts\app_%TIMESTAMP%.db"
if %ERRORLEVEL% EQU 0 (
  echo Copied app.db to docs\\artifacts\app_%TIMESTAMP%.db
) else (
  echo Failed to copy app.db. Make sure the DB exists at project root.
)
pause