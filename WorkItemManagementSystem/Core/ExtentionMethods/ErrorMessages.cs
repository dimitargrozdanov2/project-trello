using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Core.ExtentionMethods
{
    public static class Errors
    {
        public static readonly Dictionary<string, string> messages = new Dictionary<string, string>()
        {
            { "symbolsRange",  "The {} should be between {} and {} symbols!" },
            { "NoNull",  "The {} can not be null (empty)!" },
            { "Exist",  "{} {} already exist!" },
            { "NotExist",  "{} {} does not exist!" }
        };
    }
}
