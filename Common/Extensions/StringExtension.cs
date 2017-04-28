using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class StringExtension
    {
        public static string UpcaseFirst(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            
            return char.ToUpper(value[0]) + value.Substring(1);
        }

    }
}
