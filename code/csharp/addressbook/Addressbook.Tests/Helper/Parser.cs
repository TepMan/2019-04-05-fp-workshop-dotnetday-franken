using System;
using LaYumba.Functional;

namespace Addressbook.Tests.Helper
{
    public static class Parser
    {
        public static Option<DateTime> Parse(this string s)
        {
            return DateTime.TryParse(s, out var dt) 
                ? F.Some(dt) 
                : F.None;
        }
    }
}