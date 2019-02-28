using System;
using System.Collections.Generic;
using LaYumba.Functional;

using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    public class NonEmptyString : ValueObject
    {
        private NonEmptyString(string potentialString)
        {
            if (string.IsNullOrWhiteSpace(potentialString))
                throw new ArgumentException("String may not be empty or null!");

            Value = potentialString;
        }

        public string Value { get; }

        public static Option<NonEmptyString> Create(string potentialString)
        {
            Option<NonEmptyString> result;

            try
            {
                result = Some(new NonEmptyString(potentialString));
            }
            catch (Exception)
            {
                result = None;
            }

            return result;
        }

        public static NonEmptyString CreateBang(string potentialString)
        {
            return new NonEmptyString(potentialString);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}