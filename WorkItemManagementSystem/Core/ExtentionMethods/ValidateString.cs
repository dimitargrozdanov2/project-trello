using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Core.ExtentionMethods
{
    public static class ValidateString
    {
        public static bool Validate(this string input, string nullString, int min, int max)
        {
            bool result = false;
            if (min < 0)
            {
                min = 0;
            }
            if (input == null && min > 0)  // if min = 0 -- we accept empty string of null strings
            { 
                throw new ArgumentException(Errors.messages["NoNull"].ReplaceBrakets(nullString));
            }

            if (max < 0)    // No Max restriction
            {
                max = int.MaxValue;
            }

            if (min > max)
            {
                (min, max) = (max, min);  // swap values; Dot.net 7 has touples like in Python
            }

            result = input.Length < min || input.Length > max ? throw new ArgumentException(Errors.messages["symbolsRange"].ReplaceBrakets(nullString, 5, 15)) : true;

            return result;
        }
        public static string SetAndValidate(this string input, string nullString, int min, int max)
        {
            input = input.Validate(nullString, min, max) ? input : throw new ArgumentException("");
            return input;
        }
    }
}
