using System;
using System.Collections.Generic;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace AddressBook
{
    public class NonEmptyString : ValueObject
    {
        public string Value { get;}

        public static Option<NonEmptyString> Create(string value)
        {
            if (IsInvalid(value))
            {
                return None;
            }

            return Some(new NonEmptyString(value));
        }

        private NonEmptyString(string value)
        {
            Value = value;
        }

        private static bool IsInvalid(string value) 
            => string.IsNullOrWhiteSpace(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}