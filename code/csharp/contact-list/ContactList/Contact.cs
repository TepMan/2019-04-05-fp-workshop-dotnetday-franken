using System;
using System.Collections.Generic;
using ContactList.ValueObjects;
using CSharpFunctionalExtensions;

namespace ContactList
{
    // Mmh, not sure yet if this class should also be a Value Object...
    public class Contact
    {
        public Guid Id { get; set; }
        public NonEmptyString FirstName { get; set; }
        public NonEmptyString LastName { get; set; }
        public Maybe<NonEmptyString> TwitterProfileUrl { get; set; }
        public Maybe<DateTime> DateOfBirth { get; set; }
        public ContactMethod PrimaryContactMethod { get; set; }
        public IEnumerable<ContactMethod> OtherContactMethods { get; set; }
    }
}