#!/bin/bash

set -e

if [ "$ENV" = 'DEV' ]; then

echo "Running Development env"

export ASPNETCORE_ENVIRONMENT=Development

exec dotnet watch run "one.csproj"

else

echo "Running Production env"

export ASPNETCORE_ENVIRONMENT=Production

exec dotnet      publish/one.dll

fi