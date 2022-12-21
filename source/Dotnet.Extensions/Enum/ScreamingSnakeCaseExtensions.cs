using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Dotnet.Extensions.Strings;

namespace Dotnet.Extensions.Enum
{
    public static class ScreamingSnakeCaseExtensions
    {

        /// <summary>
        /// Converts the calling enum to screaming snake case
        /// </summary>
        /// <typeparam name="T">The type of enum to parse</typeparam>
        /// <param name="self">The enum itself</param>
        /// <returns>A screaming snake case representation of the enum</returns>
        public static string ToScreamingSnakeCase<T>(this T self) where T : struct, System.Enum
            => self
                   .GetType()
                   .GetField(self.ToString())
                   ?.GetCustomAttributes(typeof(EnumMemberAttribute), false)
                   ?.Cast<EnumMemberAttribute>()
                   ?.FirstOrDefault()
                   ?.Value
               ?? self.ToString().TitleToScreamingSnakeCase();

        /// <summary>
        /// Attempts to read a raw string value and convert to an enum, initially looking for an exact natural match with the field name, then tries explicitly defined name in a <see cref="EnumMemberAttribute" />, and falls back to comparing against the SCREAMING_SNAKE_CASE equivalent.
        /// </summary>
        /// <typeparam name="T">The Type of enum to parse into</typeparam>
        /// <param name="value">The raw string value, as found in Firestore</param>
        /// <returns>The matched enum member</returns>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the string cannot be reconciled with any enum member</exception>
        public static T? FromScreamingSnakeCase<T>(this string? value) where T : struct, System.Enum
        {
            if (value == null)
            {
                return null;
            }

            var result = typeof(T)
                .GetFields()
                .FirstOrDefault(i => i.Name == value || (i.EnumMemberName() == value) || i.Name == value?.ScreamingSnakeToTitleCase())
                ?.GetRawConstantValue();

            if (result == null)
            {
                throw new InvalidEnumArgumentException($"{value} is not serializable to type {typeof(T).Name}");
            }
            else
            {
                return (T)result;
            }
        }
    }
}
