#!/bin/bash

set -x

CURDIR=$pwd

rm -rf ./build/Java/com/sates/test/java && \
find ./codes/sates_test_java/src/com/sates/ -type  f -name "*.java" > src.txt && \
mkdir -p ./build/Java && \
javac -d ./build/Java @src.txt && \
rm -rf src.txt && \
cd build/Java && \
jar -cf sates_test_java.jar com/sates/test/java

cd $CURDIR
