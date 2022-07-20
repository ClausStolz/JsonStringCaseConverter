using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JsonStringCaseConverter
{
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
        /// <param name="source">
        /// A string in camelCase or PascalCase format.
        /// </param>
        public static string ToSnakeCase(this string? source)
        {
            if (string.IsNullOrEmpty(source)) return source ?? string.Empty;

            var words = source.Split();
            var result = new StringBuilder("");

            foreach (var word in words.Select((c, i) => new { indx = i, value = c }))
            {
                if (word.indx > 0)
                {
                    result.Append(' ');
                }

                foreach (var subWord in word.value.SplitForWords().Select((c, i) => new { indx = i, value = c }))
                {
                    result.Append(subWord.indx > 0
                        ? $"_{subWord.value}"
                        : subWord.value
                    );
                }
            }

            return result.ToString().ToLower();
        }
        
        /// <summary>
        /// Convert in CONSTANT_CASE format.
        /// </summary>
        /// <param name="source">
        /// A string in camelCase or PascalCase format.
        /// </param>
        public static string ToConstantCase(this string? source)
        {
            if (string.IsNullOrEmpty(source)) return source ?? string.Empty;

            return source.ToSnakeCase().ToUpper();
        }

        /// <summary>
        /// Convert in PascalCase format.
        /// </summary>
        /// <param name="source">
        /// A string in PascalCase or snake_case format.
        /// </param>
        /// <param name="saveUpperCase">
        /// The identifier to save uppercase words for string.
        /// </param>
        public static string ToPascalCase(this string? source, bool saveUpperCase = false)
        {
            if (string.IsNullOrEmpty(source)) return source ?? string.Empty;

            var words = source.Split();
            var result = new StringBuilder("");

            foreach (var word in words.Select((c, i) => new { indx = i, value = c }))
            {
                if (word.indx > 0)
                {
                    result.Append(' ');
                }

                foreach (var subWord in word.value.SplitForWords())
                {
                    result.Append(saveUpperCase
                        ? char.ToUpper(subWord[0]) + subWord[1..]
                        : char.ToUpper(subWord[0]) + subWord[1..].ToLower()
                    );
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Convert in camelCase format.
        /// </summary>
        /// <param name="source">
        /// A string in PascalCase or snake_case format.
        /// </param>
        /// <param name="saveUpperCase">
        /// The identifier to save uppercase words for string.
        /// </param>
        public static string ToCamelCase(this string? source, bool saveUpperCase = false)
        {
            if (string.IsNullOrEmpty(source)) return source ?? string.Empty;

            var words = source.Split(' ');
            var result = new StringBuilder("");

            foreach (var word in words.Select((c, i) => new { indx = i, value = c }))
            {
                if (word.indx > 0)
                {
                    result.Append(' ');
                }

                foreach (var subWord in word.value.SplitForWords().Select((c, i) => new { indx = i, value = c }))
                {
                    if (saveUpperCase && !subWord.value.Any(x => char.IsLetter(x) && char.IsLower(x)))
                    {
                        result.Append(subWord.value);
                    }
                    else
                    {
                        result.Append(subWord.indx > 0
                            ? char.ToUpper(subWord.value[0]) + subWord.value[1..].ToLower()
                            : char.ToLower(subWord.value[0]) + subWord.value[1..].ToLower()
                        );
                    }
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Split string for words with saving register.
        /// </summary>
        /// <param name="source">
        /// A string that will be split into individual words,
        /// preserving their case.
        /// </param>
        public static IEnumerable<string> SplitForWords(this string source)
        {
            if (string.IsNullOrEmpty(source)) return new[] { string.Empty };

            var r = new Regex(@"
            (?<=[A-Z])(?=[A-Z][a-z]) |
            (?<=[^A-Z])(?=[A-Z]) |
            (?<=[A-Za-z])(?=[^A-Za-z])",
                RegexOptions.IgnorePatternWhitespace
            );

            return r.Split(source.Replace('_', ' '))
                .Select(x => x.Replace(" ", ""))
                .Where(x => !string.IsNullOrEmpty(x));
        }
    }
}