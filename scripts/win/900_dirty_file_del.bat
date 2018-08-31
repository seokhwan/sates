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
rmdir _PRIVATE\plantuml\output /s /q

rmdir scripts\win\output /s /q

REM rmdir build\Debug /s /q
REM rmdir build\Release /s /q
rmdir build\Java /s /q
rmdir outfiles /s /q

rmdir example\java_test\out /s /q
rmdir example\java_code\out /s /q
rmdir example\javaout /s /q



rmdir codes\sates_test_java\out /s /q


cd %CURDIR%