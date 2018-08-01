SET CURDIR=%~dp0
SET ROOT_DIR=%CURDIR%\..\..\
cd %ROOT_DIR%
SET ROOT_DIR=%cd%

cd codes

rmdir Debug /s /q
rmdir Release /s /q

rmdir .vs /s /q

rmdir sates_core\obj /s /q
rmdir sates_test_cs\obj /s /q
rmdir test_sates_core\obj /s /q

rmdir sates_test_cpp\Debug /s /q
rmdir sates_test_cpp\Release /s /q

cd ..\
rmdir _dirty\plantuml\output /s /q

rmdir scripts\win\output /s /q

rmdir build /s /q
rmdir outfiles /s /q


cd %CURDIR%