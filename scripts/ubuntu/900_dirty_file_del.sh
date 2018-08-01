#!/bin/bash

CURDIR=$(cd)
ROOT_DIR=$CURDIR../../
cd $ROOT_DIR


cd codes

rm -rf  Debug
rm -rf  Release

rm -rf .vs

rm -rf sates_core/obj 
rm -rf sates_test_cs/obj 
rm -rf test_sates_core/obj 

rm -rf sates_test_cpp/Debug
rm -rf sates_test_cpp/Release 

cd ../
rm -rf _dirty/plantuml/output

rm -f scripts/win/output

rm -rf build 
rm -rf outfiles


cd $CURDIR
