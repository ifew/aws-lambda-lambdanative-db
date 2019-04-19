#!/bin/bash

#
# SHOULD BUILD IMAGE BEFORE
# docker build -t lambdanative .
#

rm -f $(pwd)/output/bootstrap
rm -f $(pwd)/output/package.zip
docker run --rm -v $(pwd)/output:/app/out lambdanative:testdb
cd output
cp aws-lambda-lambdanative bootstrap
zip package.zip bootstrap
aws s3 cp package.zip s3://backend-layer --profile sansiri