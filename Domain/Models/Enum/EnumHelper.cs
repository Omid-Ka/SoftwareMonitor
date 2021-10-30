using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Models.Enum
{
    public static class EnumHelper
    {
        public static string ToDescription(this System.Enum value)
        {
            if (value == null)
                return "";
            var d = value.GetType().GetField(value.ToString());
            if (d == null) return "";
            var attributes = (DescriptionAttribute[])d.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var desc = attributes.Length > 0 ? attributes[0].Description : value.ToString();
            return desc;
        }

    }
}
