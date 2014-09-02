using System;
using System.ComponentModel;
using System.Linq;

namespace App.ConsoleApp
{
    public static class UtilityExtensions
    {
        /// <summary>
        /// Helper method to retrieve a string value bound to an enumeration value.
        /// </summary>
        public static string GetDescription(this Enum value)
        {
            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
