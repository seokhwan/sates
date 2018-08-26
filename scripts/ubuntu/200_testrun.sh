#!/bin/bash

CURDIR=$pwd
echo $CURDIR

cd ../../

coverlet ./build/Debug/netcoreapp2.1/test_sates_core.dll --target "dotnet" --targetargs "test codes/test_sates_core/test_sates_core.csproj --no-build" --format cobertura
cp "coverage.cobertura.xml" "outfiles/coverage.cobertura.xml"

cd $CURDIR

