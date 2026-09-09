#!/usr/bin/env bash
set -e
dotnet restore
dotnet build
dotnet run --urls http://0.0.0.0:5080
