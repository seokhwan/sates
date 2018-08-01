call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsDevCmd.bat"
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\WDExpress\Common7\Tools\VsDevCmd.bat"

SET CURDIR=%~dp0
SET ROOT_DIR=%CURDIR%\..\..\
cd %ROOT_DIR%
SET ROOT_DIR=%cd%

cd codes

dotnet build sates_core\sates_core.csproj --configuration Debug --no-incremental
dotnet build sates_core\sates_core.csproj --configuration Release --no-incremental

dotnet build sates_test_cs\sates_test_cs.csproj --configuration Debug --no-incremental
dotnet build sates_test_cs\sates_test_cs.csproj --configuration Release --no-incremental

dotnet build test_sates_core\test_sates_core.csproj --configuration Debug --no-incremental
dotnet build test_sates_core\test_sates_core.csproj --configuration Release --no-incremental


cd %CURDIR%