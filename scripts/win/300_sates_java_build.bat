set PATH=%PATH%;C:\Program Files\Java\jdk1.8.0_181\bin

SET CURDIR=%~dp0
cd ..\..\
SET ROOT_DIR=%cd%

rmdir build\Java\com\sates\test\java /s /q
mkdir build\Java

dir /s /B codes\sates_test_java\src\com\sates\test\java\*.java > src.txt
javac -d build\Java @src.txt

del src.txt

cd build\Java\

jar -cf sates_test_java.jar com\sates\test\java

cd %CURDIR%


