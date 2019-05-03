# Example AWS Lambda C# .NET Core 3 (and 2.2) Runtime (CoreRT) with connect MySQL via not using any ORM

Example for optimize cold start with Lambda Native

## Dependency

- https://github.com/dotnet/corert
- https://github.com/ifew/lambda-native/

## Test via 

```bash
docker run --rm -v "$PWD":/var/task lambci/lambda:provided handler ''
```

### Build file and packing to output/package.zip

```bash
sh build.sh
```

### Upload to aws s3

```bash
aws s3 cp package.zip s3://backend-layer [--profile AWS-PROFILE-NAME]
```