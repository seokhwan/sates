call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsDevCmd.bat"
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\WDExpress\Common7\Tools\VsDevCmd.bat"

dotnet tool install --global coverlet.console 

SET CURDIR=%~dp0
SET ROOT_DIR=%CURDIR%\..\..\
cd %ROOT_DIR%
SET ROOT_DIR=%cd%

coverlet build\Debug\netcoreapp2.1\test_sates_core.dll --target "dotnet" --targetargs "test codes\test_sates_core\test_sates_core.csproj --no-build" --format cobertura
move /-y "coverage.cobertura.xml" "outfiles\coverage.cobertura.xml"

cd %CURDIR%