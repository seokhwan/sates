call 100_build.bat
call 200_testrun.bat
call 210_cov_report_csharp.bat

SET CURDIR=%~dp0

cd ..\..\

cd outfiles

call doxyrun_chm.bat
call doxyrun_html.bat

cd %CURDIR%

