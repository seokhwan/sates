SET CURDIR=%~dp0
SET ROOT_DIR=%CURDIR%\..\..\
cd %ROOT_DIR%
SET ROOT_DIR=%cd%

SET PATH=%PATH%;%ROOT_DIR%\deps_win\ReportGenerator

cd outfiles

reportgenerator -reports:coverage.cobertura.xml -targetdir:cov_report_csharp

cd %CURDIR%