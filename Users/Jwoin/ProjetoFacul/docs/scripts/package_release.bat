@echo off
REM Prepare artifacts folder
if not exist "%~dp0artifacts" mkdir "%~dp0artifacts"

REM Copy DB if exists
if exist "%~dp0..\app.db" (
    copy /Y "%~dp0..\app.db" "%~dp0artifacts\app.db" >nul
    echo Copied app.db to docs\artifacts\app.db
) else (
    echo Warning: app.db not found at project root
)

REM Ensure technical pdf exists
if exist "%~dp0..\docs\technical-report.pdf" (
    copy /Y "%~dp0..\docs\technical-report.pdf" "%~dp0artifacts\technical-report.pdf" >nul
) 

REM Create release zip using PowerShell Compress-Archive
powershell -NoProfile -Command "Compress-Archive -Path \"..\README.md\", \"..\ProjetoFacul.sln\", \"..\ProjetoFacul.csproj\", \"..\Migrations\", \"..\Controllers\", \"..\core\", \"..\Data\", \"..\Services\", \"..\Repositories\", \"..\docs\postman\", \"..\docs\technical-report.pdf\", \"..\app.db\" -DestinationPath \"artifacts\ProjetoFacul_release.zip\" -Force"

if exist "%~dp0artifacts\ProjetoFacul_release.zip" (
    echo Release package created: docs\artifacts\ProjetoFacul_release.zip
) else (
    echo Failed to create release ZIP
)
pause