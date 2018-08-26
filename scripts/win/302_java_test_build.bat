set PATH=%PATH%;C:\Program Files\Java\jdk1.8.0_181\bin

SET CURDIR=%~dp0
cd ..\..\
SET ROOT_DIR=%cd%

rmdir build\Java\TEST /s /q

dir /s /B example\java_test\src\TEST\*.java > src.txt
javac -cp build\Java\sates_test_java.jar;build\Java\java_code.jar -d build\Java @src.txt

del src.txt

cd build\Java

copy ..\..\example\java_test\Manifest.MF

jar -cmf Manifest.MF java_test.jar TEST

del Manifest.MF

cd %CURDIR%


