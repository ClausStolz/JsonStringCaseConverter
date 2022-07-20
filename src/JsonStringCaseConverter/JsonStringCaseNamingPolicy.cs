using System.Text.Json;

namespace JsonStringCaseConverter;

/// <summary>
/// Improved <see cref="JsonNamingPolicy"/> class to easily
/// implement case conversion.
/// </summary>
public class JsonStringCaseNamingPolicy : JsonNamingPolicy
{
    private readonly StringCases _stringCase;

    /// <summary>
    /// Constructor that takes as an argument the rule needed
    /// for case conversion.
    /// </summary>
    /// <param name="stringCase">
    /// An enumeration element denoting the desired case type.
    /// </param>
    public JsonStringCaseNamingPolicy(StringCases stringCase)
    {
        _stringCase = stringCase;
    }
    
    /// <summary>
    /// Converts a value based on the the specified case type
    /// according to the policy.
    /// </summary>
    /// <param name="name">
    /// The value to convert.
    /// </param>
    public override string ConvertName(string name) =>
        _stringCase switch
        {
            StringCases.SnakeCase => name.ToSnakeCase(),
            StringCases.CamelCase => name.ToCamelCase(),
            StringCases.PascalCase => name.ToPascalCase(),
            _ => throw new ArgumentOutOfRangeException(),
        };
}