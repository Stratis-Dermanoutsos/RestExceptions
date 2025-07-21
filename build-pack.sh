#!/bin/bash
set -e

cd ./src/RestExceptions
dotnet clean
dotnet build -c Release
dotnet pack -c Release

# To run:
# chmod +x build-pack.sh
