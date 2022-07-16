
# JsonStringCaseConverter

![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)
[![NuGet Badge](https://buildstats.info/nuget/SmartEnums)](https://www.nuget.org/packages/SmartEnums/)

# Info

JsonStringCaseConverter is the string case formatting extensions for [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json?view=net-5.0).

This library helps to convert strings to the following formats:
- [x] Camel case;
- [x] Pascal case;
- [x] Snake case;
- [ ] Cebab case (comming soon).

# Installation

Either checkout this Github repository or install `JsonStringCaseConverter` via NuGet Package Manager. 

If you want to use NuGet just search for `JsonStringCaseConverter` or run the following command in the NuGet Package Manager console:

`PM> Install-Package JsonStringCaseConverter`

# Usage

## In a part of System.Text.Json

To work with the object, use the inherited class `JsonStringCaseNamingPolicy`.
The `JsonStringCaseNamingPolicy` class receives one of the formats you need in the constructor stored in the `StringCases` enam.
The following formats are currently available:

```csharp
public enum StringCases
{
    CamelCase,
    SnakeCase,
    PascalCase
}
```

To configure for JsonSerializer directly:

```csharp 
var options = new JsonSerializerOptions()
{
    PropertyNamingPolicy = new JsonStringCaseNamingPolicy(StringCases.CamelCase)
};

var json = JsonSerializer.Serialize(obj, options);
```

To configure for .NET Core project:

```csharp
services.AddControllers()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(StringCases.PascalCase)
    });
```

To configure for .NET 6.0 Minimal API:

```csharp
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(StringCases.SnakeCase));
});
```

## In a native work with strings

The library has direct extension methods that can be used with non-json strings if you need them.

```csharp
var camelText = someText.ToCamelCase();

var snakeText = someText.ToSnakeCase();

var pascalText = someText.ToPascalCase();
```
