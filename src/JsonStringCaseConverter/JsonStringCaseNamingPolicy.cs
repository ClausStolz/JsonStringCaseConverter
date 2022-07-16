using System.Text.Json;

namespace JsonStringCaseConverter;

public class JsonStringCaseNamingPolicy : JsonNamingPolicy
{
    private readonly StringCases _stringCase;

    public JsonStringCaseNamingPolicy(StringCases stringCase)
    {
        _stringCase = stringCase;
    }
    
    public override string ConvertName(string name) =>
        _stringCase switch
        {
            StringCases.SnakeCase => name.ToSnakeCase(),
            StringCases.CamelCase => name.ToCamelCase(),
            StringCases.PascalCase => name.ToPascalCase(),
            _ => throw new ArgumentOutOfRangeException(),
        };
}