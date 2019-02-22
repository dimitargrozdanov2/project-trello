using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Core.ExtentionMethods
{
    public static class ReplaceBraketsWithValues
    {
        public static string ReplaceBrakets(this string input, params object[] s)
        {
            int first = input.IndexOf("{");
            string result = "";
            if (first >= 0)
            {
                string[] splitStr = input.Split("{}");
                int i = 0;
                for (int j = 0; j < splitStr.Length; j++)
                {
                    result += splitStr[j] + (j < splitStr.Length - 1 ? s[i].ToString() : "");
                    i = (i < s.Length - 1) ? i + 1 : 0;
                }
            }
            else
            {
                result = input;
            }
            return result;
        }
    }
}
