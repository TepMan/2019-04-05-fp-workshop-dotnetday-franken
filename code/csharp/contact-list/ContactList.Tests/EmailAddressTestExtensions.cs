using System;
using CSharpFunctionalExtensions;

namespace ContactList.Tests
{
    public static class EmailAddressTestExtensions
    {
        // public static bool HasExpectedEmail
        //     (this Maybe<EmailAddress2> x, string y) => x.HasValue && x.Value == y;

        public static bool IsOkAndHasValue<T>(this Maybe<T> maybe, T expected) 
        {
            if (maybe.HasNoValue)
            {
                return false;
            }

            return maybe.Value.Equals(expected);
        }
    }
}