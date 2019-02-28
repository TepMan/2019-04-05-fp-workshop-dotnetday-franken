using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Addressbook.ValueObjects
{
    public class NonEmptyString : ValueObject
    {
        private NonEmptyString(string potentialString)
        {
            if (string.IsNullOrWhiteSpace(potentialString))
            {
                throw new ArgumentException("String may not be empty or null!");
            }

            Value = potentialString;
        }

        public string Value { get; }
        
        public static Maybe<NonEmptyString> Create(string potentialString)
        {
            Maybe<NonEmptyString> result;

            try
            {
                result = Maybe<NonEmptyString>.From(new NonEmptyString(potentialString)); 
            }
            catch (Exception)
            {
                result = Maybe<NonEmptyString>.None;
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