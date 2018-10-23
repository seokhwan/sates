#!/bin/bash

set -x

CURDIR=$pwd
echo $CURDIR

cd ../../
rm -rf ./build/Java/TEST

find ./example/java_test/src/TEST/ -type  f -name "*.java" > src.txt

javac -cp ./build/Java/sates_test_java.jar:./build/Java/java_code.jar  -d ./build/Java @src.txt

rm -rf src.txt

cd build/Java

cp ../../example/java_test/Manifest.MF ./

jar -cmf Manifest.MF java_test.jar TEST

rm -rf  Manifest.MF

cd $CURDIR


