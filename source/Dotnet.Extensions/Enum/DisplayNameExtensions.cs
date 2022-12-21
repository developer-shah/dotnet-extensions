using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Extensions.Enum
{
    public static class DisplayNameExtensions
    {
        /// <summary>
        /// Returns Display(Name) attribute of Enum value, if no Display name is set will return EnumValue.ToString()
        /// </summary>
        /// <param name="self">The instance</param>
        /// <returns>The contents of the Display attribute, or if that is not present, the enum.ToString</returns>
        public static string DisplayName(this System.Enum self)
            => self?
                   .GetType()
                   .GetField(self.ToString())
                   ?.GetCustomAttribute<DisplayAttribute>()
                   ?.Name
               ?? self?.ToString() ?? string.Empty;
    }
}
