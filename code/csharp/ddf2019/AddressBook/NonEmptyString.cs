using System;
using System.Collections.Generic;

namespace AddressBook
{
    public class NonEmptyString : ValueObject
    {
        public string Value { get;}

        public NonEmptyString(string value)
        {
            if (IsInvalid(value))
                throw new ArgumentException("value must not be empty");
            
            Value = value;
        }

        private bool IsInvalid(string value) 
            => string.IsNullOrWhiteSpace(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}