using System;
using System.Collections.Generic;
using LaYumba.Functional;
using Newtonsoft.Json;
using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    public class NonEmptyString : ValueObject
    {
        [JsonConstructor] 
        private NonEmptyString(string potentialString)
        {
            if (IsValid(potentialString))
                throw new ArgumentException("String may not be empty or null!");

            Value = potentialString;
        }

        private static bool IsValid(string potentialString) => !string.IsNullOrWhiteSpace(potentialString);

        public string Value { get; }

        // smart ctor
        public static Func<string, Option<NonEmptyString>> Create 
            = s => IsValid(s)
                ? Some(new NonEmptyString(s))
                : None;

        [Obsolete]
        public static Option<NonEmptyString> CreateClassic(string potentialString)
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