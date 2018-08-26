SET PATH=%PATH%;D:\bsd\sates\deps_win\ReportGenerator

SET CURDIR=%~dp0
SET ROOT_DIR=%CURDIR%\..\..\
cd %ROOT_DIR%
SET ROOT_DIR=%cd%

cd outfiles

reportgenerator -reports:coverage.cobertura.xml -targetdir:cov_report_csharp

cd %CURDIR%