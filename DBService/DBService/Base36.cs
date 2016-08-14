using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBService
{
    public static class Base36
    {
        const string CharList = "0123456789abcdefghijklmnopqrstuvwxyz";

        public static int DecodeFromBase(this string input)
        {
            var reversed = input.ToLower().Reverse();
            int result = 0;
            int pos = 0;
            foreach (char c in reversed)
            {
                result += CharList.IndexOf(c) * (int)Math.Pow(36, pos);
                pos++;
            }
            return result;
        }

    }
}