namespace JsonStringCaseConverter
{
    /// <summary>
    /// The enum contains the supported case formats for
    /// processing in extensions.
    /// </summary>
    public enum StringCases
    {
        /// <summary>
        /// Camel case is the practice of writing phrases without
        /// spaces or punctuation. It indicates that the separation
        /// of words with a single capitalized letter, and the first
        /// word starting with either case.
        /// </summary>
        /// <example>
        /// camelCase, myVariableInCamelCase 
        /// </example>
        CamelCase,

        /// <summary>
        /// Pascal case is the practice of writing phrases without
        /// spaces or punctuation. It indicates that the starting
        /// and the separation of words with a single capitalized
        /// letter.
        /// </summary>
        /// /// <example>
        /// PascalCase, MyVariableInPascalCase 
        /// </example>
        PascalCase,

        /// <summary>
        /// Snake case is the practice of writing phrases without
        /// spaces or punctuation. It indicates that the separation
        /// of words with an underscore.
        /// </summary>
        /// /// /// <example>
        /// snake_case, my_variable_in_snake_case 
        /// </example>
        SnakeCase,
        
        /// <summary>
        /// Constant case is the practice of writing phrases without
        /// spaces or punctuation. It indicates that the separation
        /// of words with an underscore and all letters in upper
        /// register. 
        /// </summary>
        /// /// <example>
        /// CONSTANT_CASE, MY_VARIABLE_IN_CONSTANT_CASE 
        /// </example>
        ConstantCase
    }
}