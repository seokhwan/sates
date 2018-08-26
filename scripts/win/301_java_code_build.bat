set PATH=%PATH%;C:\Program Files\Java\jdk1.8.0_181\bin

SET CURDIR=%~dp0
cd ..\..\
SET ROOT_DIR=%cd%

rmdir build\Java\com\sates\example /s /q

dir /s /B example\java_code\src\com\sates\example\*.java > src.txt
javac -d build\Java @src.txt

del src.txt

cd build\Java\

jar -cf java_code.jar com\sates\example

cd %CURDIR%

