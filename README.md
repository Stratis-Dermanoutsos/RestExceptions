# RestExceptions

Extensible Web API middleware that maps all exceptions to standardized REST-compliant error responses.

## NuGet Packages

| RestExceptions Package                                          | NuGet                                                                                                                                          |
|-----------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| [RestExceptions](https://www.nuget.org/packages/RestExceptions) | [<img src='https://img.shields.io/nuget/v/RestExceptions' alt='rest-exceptions-nuget-version'>](https://www.nuget.org/packages/RestExceptions) |

## Usage

```csharp
// Program.cs

var builder = WebApplication.CreateBuilder(args);

// ...

// Add the service
builder.Services.AddRestExceptions();

var app = builder.Build();

//! Important
app.UseExceptionHandler();

// ...

app.Run();
```

## Examples and sample project

A minimal API utilizing **RestExceptions** is included in the project files as an example.

## Disclaimer

This project was generated using [Stratis-Dermanoutsos/dotnet-empty-solution](https://github.com/Stratis-Dermanoutsos/dotnet-empty-solution).
