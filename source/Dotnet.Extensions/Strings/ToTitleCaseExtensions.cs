using System.Globalization;

namespace Dotnet.Extensions.Strings
{
    public static class ToTitleCaseExtensions
    {
        /// <summary>
        /// Converts the specified string to title case (except for words  that are entirely in uppercase, which are considered to be acronyms)
        /// </summary>
        /// <param name="self">The source string.</param>
        /// <returns>The specified string converted to title case.</returns>
        /// <example>var result = myString.ToTitleCase(); // turns "this string. like this." into "This String. Like This."</example>
        /// <remarks>Note: This assumes any words in all caps to be acronyms, and does not change them. If this is not desired, consider calling .ToLower() first.</remarks>
        public static string ToTitleCase(this string self)
            => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(self ?? string.Empty);
    }
}
