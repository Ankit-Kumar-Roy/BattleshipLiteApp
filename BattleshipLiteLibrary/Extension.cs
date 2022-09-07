using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary
{
    public static class Extension
    {
        public static bool IsValidGridNumber(this string input)
        {
            bool output = false;
            if (int.TryParse(input, out int result) && result >= 1 && result <= 5)
            {
                output = true;
            }
            return output;
        }

        public static bool IsValidGridLetter(this string input)
        {
            bool output = false;
            if (input.ToUpper().IndexOfAny(new char[] { 'A', 'B', 'C', 'D', 'E' }) > -1)
            {
                output = true;
            }
            return output;
        }
    }
}
