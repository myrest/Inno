using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.Core.Utility.Extension
{
    public static class StringExtension
    {
        public static string ConvertNewLine2Br(this string s)
        {
            return s.Replace("\r", "\n").Replace("\n\n", "\n").Replace("\n", "<br>"); 
        }
    }
}
