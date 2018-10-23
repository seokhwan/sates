#!/bin/bash

# Install .NET SDK
if [[ "$1" = "prebuild" ]]
then
  sudo rpm -Uvh https://packages.microsoft.com/config/rhel/7/packages-microsoft-prod.rpm && \
  sudo yum update && \
  sudo yum install -y dotnet-sdk-2.1 && \
  dotnet tool install --global coverlet.console

  sudo yum install -y java-1.8.0-openjdk-devel
fi

# build sates_core
dotnet build ./codes/sates_core/sates_core.csproj --configuration Debug --no-incremental && \
dotnet build ./codes/sates_core/sates_core.csproj --configuration Release --no-incremental

# build sates_test_cs
dotnet build ./codes/sates_test_cs/sates_test_cs.csproj --configuration Debug --no-incremental && \
dotnet build ./codes/sates_test_cs/sates_test_cs.csproj --configuration Release --no-incremental

# build test_sates_core
dotnet build ./codes/test_sates_core/test_sates_core.csproj --configuration Debug --no-incremental && \
dotnet build ./codes/test_sates_core/test_sates_core.csproj --configuration Release --no-incremental
