using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Extensions.Strings
{
    public static class ScreamingSnakeCaseExtensions
    {
        /// <summary>
        /// Converts a string from TitleCase to SCREAMING_SNAKE_CASE
        /// </summary>
        /// <param name="value">A TitleCase or camelCase string</param>
        /// <returns>The converted string in SCREAMING_SNAKE_CASE</returns>
        public static string TitleToScreamingSnakeCase(this string? value)
            => string.IsNullOrEmpty(value)
                ? string.Empty
                : string.Concat(
                    value.Select((x, i) => i > 0 && char.IsUpper(x)
                        ? "_" + x.ToString()
                        : x.ToString())).ToUpperInvariant();

        /// <summary>
        /// Converts a string from SCREAMING_SNAKE_CASE to TitleCase
        /// </summary>
        /// <param name="self">A string in SCREAMING_SNAKE_CASE</param>
        /// <returns>The converted string in TitleCase</returns>
        public static string ScreamingSnakeToTitleCase(this string? self)
            => string.IsNullOrEmpty(self)
                ? string.Empty
                : string.Concat(self
                    .Split('_')
                    .Select(i => i.ToLowerInvariant())
                    .Select(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase));
    }
}
