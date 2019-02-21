using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace ContactList.ValueObjects
{
    public class NonEmptyString : ValueObject
    {
        private NonEmptyString(string potentialString)
        {
            if (string.IsNullOrWhiteSpace(potentialString))
            {
                throw new ArgumentException();
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}