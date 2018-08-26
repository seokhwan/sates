#!/bin/bash

set -x

CURDIR=$pwd
echo $CURDIR

cd ../../
rm -rf ./build/Java/com/sates/example

find ./example/java_code/src/com/sates/example/ -type  f -name "*.java" > src.txt

javac -d ./build/Java @src.txt

rm -rf src.txt

cd build/Java

jar -cf java_code.jar com/sates/example

cd $CURDIR

