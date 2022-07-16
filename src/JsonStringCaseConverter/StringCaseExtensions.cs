using System.Text;

namespace JsonStringCaseConverter;

/// <summary>
/// Extension to convert string values to others case formats.
/// All formats are written in the same syntactic style they describe.
/// This is done to better understand how the syntax of a particular case works.
/// </summary>
public static class StringCaseConvertExtension
{
    /// <summary>
    /// Convert in snake_case format.
    /// </summary>
    /// <param name="value">String in camelCase or PascalCase format.</param>
    public static string ToSnakeCase(this string value)
    {
        var words = value.Split(' ');
        var result = new StringBuilder("");
        
        foreach (var word in words.Select((c, i) => new {indx = i, value = c}))
        {
            if (word.indx > 0)
            {
                result.Append(' ');
            }
            foreach (var letter in word.value.Select((c, i) => new { indx = i, value = c }))
            {
                result.Append(letter.indx > 0 && char.IsUpper(letter.value)
                    ? $"_{letter.value}"
                    : letter.value.ToString());
            }
        }
        return result.ToString().ToLower();
    }

    /// <summary>
    /// Convert in PascalCase format.
    /// </summary>
    /// <param name="value">String in PascalCase or snake_case format.</param>
    public static string ToPascalCase(this string value)
    {
        var words = value.Split(' ');
        var result = new StringBuilder("");
        
        foreach (var word in words.Select((c, i) => new {indx = i, value = c}))
        {
            if (word.indx > 0)
            {
                result.Append(' ');
            }

            foreach (var subWord in word.value.Split('_'))
            {
                result.Append(char.ToUpper(subWord[0]) + subWord[1..]);
            }
        }
        return result.ToString();
    }

    /// <summary>
    /// Convert in camelCase format.
    /// </summary>
    /// <param name="value">String in PascalCase or snake_case format.</param>
    public static string ToCamelCase(this string value)
    {
        var words = value.Split(' ');
        var result = new StringBuilder("");
    
        foreach (var word in words.Select((c, i) => new {indx = i, value = c}))
        {
            if (word.indx > 0)
            {
                result.Append(' ');
            }

            foreach (var subWord in word.value.Split('_').Select((c, i) => new {indx = i, value = c }))
            {
                result.Append(subWord.indx > 0
                    ? char.ToUpper(subWord.value[0]) + subWord.value[1..]
                    : char.ToLower(subWord.value[0]) + subWord.value[1..]);
            }
        }
        return result.ToString();
    }
}