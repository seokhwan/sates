#!/bin/bash

CURDIR=$pwd
echo $CURDIR

cd ../../
cd codes

dotnet build ./sates_core/sates_core.csproj --configuration Debug --no-incremental
dotnet build ./sates_core/sates_core.csproj --configuration Release --no-incremental

dotnet build ./sates_test_cs/sates_test_cs.csproj --configuration Debug --no-incremental
dotnet build ./sates_test_cs/sates_test_cs.csproj --configuration Release --no-incremental

dotnet build ./test_sates_core/test_sates_core.csproj --configuration Debug --no-incremental
dotnet build ./test_sates_core/test_sates_core.csproj --configuration Release --no-incremental

cd $CURDIR

