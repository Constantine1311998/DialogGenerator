using System;
using System.ComponentModel;
using System.Linq;

namespace DialogGenerator.Extension
{
    /// <summary>
    /// Extension Methods for Enum Description
    /// </summary>
    public static class EnumDescriptionExtension
    {
        /// <summary>
        /// Returns the description stored in description attribute
        /// </summary>
        /// <param name="e">Enum that is passed in as extension</param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum e)
        {
            string name = e.ToString();
            var memberInfo = e.GetType().GetMember(name).FirstOrDefault();
            if (memberInfo != null)
            {
                var descriptionAttributes = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false).FirstOrDefault() as DescriptionAttribute;
                if (descriptionAttributes != null)
                {
                    return descriptionAttributes.Description;
                }
            }
            return name;
        }
    }
}