set PATH=%PATH%;C:\Program Files\Java\jdk1.8.0_181\bin

SET CURDIR=%~dp0
cd ..\..\
SET ROOT_DIR=%cd%

cd build\Java

java -jar java_test.jar

cd %CURDIR%


