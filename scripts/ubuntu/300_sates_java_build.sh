#!/bin/bash

set -x

CURDIR=$pwd
echo $CURDIR

cd ../../
rm -rf ./build/Java/com/sates/test/java

find ./codes/sates_test_java/src/com/sates/ -type  f -name "*.java" > src.txt

javac -d ./build/Java @src.txt

rm -rf src.txt

cd build/Java

jar -cf sates_test_java.jar com/sates/test/java

cd $CURDIR

