using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Extensions.Enum
{
    public static class EnumMemberExtensions
    {
        /// <summary>
        /// Returns EnumMember(Name) attribute of Enum value, if no EnumMember is set will return EnumValue.ToString()
        /// </summary>
        /// <param name="self">The instance</param>
        /// <returns>The contents of the EnumMember attribute, or if that is not present, the enum.ToString</returns>
        public static string EnumMemberName(this System.Enum self)
            => self?
                   .GetType()
                   .GetField(self.ToString())
                   ?.GetCustomAttribute<EnumMemberAttribute>()
                   ?.Value
               ?? self?.ToString() ?? string.Empty;

        public static string? EnumMemberName(this FieldInfo? field)
            => field
                   ?.GetCustomAttributes(typeof(EnumMemberAttribute), false)
                   ?.Cast<EnumMemberAttribute>()
                   ?.FirstOrDefault()
                   ?.Value
               ?? field?.Name ?? string.Empty;
    }
}
