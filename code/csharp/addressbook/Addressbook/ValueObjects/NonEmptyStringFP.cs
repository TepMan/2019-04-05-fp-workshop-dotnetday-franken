using System;
using System.Collections.Generic;
using LaYumba.Functional;

namespace Addressbook.ValueObjects
{
    // Functional solution
    // - private ctor
    // - smart ctor `Create`
    // - no validation inside ctor
    public class NonEmptyStringFP : ValueObject
    {
        public string Value { get; }

        private NonEmptyStringFP(string potentialString) => Value = potentialString;

        // smart ctor
        public static Func<string, Option<NonEmptyStringFP>> Create 
            = s => s.IsNonEmpty()
                ? F.Some(new NonEmptyStringFP(s))
                : F.None;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(NonEmptyStringFP nonEmptyStringFP)
        {
            return nonEmptyStringFP.Value;
        }

        public override string ToString() => Value;
    }
}