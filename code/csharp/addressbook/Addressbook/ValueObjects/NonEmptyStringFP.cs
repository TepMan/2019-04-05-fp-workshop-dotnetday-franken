using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    // Functional solution
    // - private ctor
    // - smart ctor
    // - no validation inside ctor
    public class NonEmptyStringFP
    {
        public string Value { get; }

        private NonEmptyStringFP(string potentialString) => Value = potentialString;

        // smart ctor
        public static Func<string, Option<NonEmptyStringFP>> Create 
            = s => !string.IsNullOrWhiteSpace(s)
                ? Some(new NonEmptyStringFP(s))
                : None;
    }
}