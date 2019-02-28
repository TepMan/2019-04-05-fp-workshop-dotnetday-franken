using System;
using System.Collections.Generic;
using DemoCsharp.Addressbook.ValueObjects;
using CSharpFunctionalExtensions;

namespace DemoCsharp.Addressbook
{
    // Mmh, not sure yet if this class should also be a Value Object...
    public class Contact
    {
        public Contact(Guid id, 
            NonEmptyString firstname, 
            NonEmptyString lastname, 
            Maybe<DateTime> dateOfBirth,
            Maybe<NonEmptyString> twitterProfileUrl, 
            ContactMethod primaryContactMethod, 
            IEnumerable<ContactMethod> otherContactMethod)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateOfBirth;
            TwitterProfileUrl = twitterProfileUrl;
            PrimaryContactMethod = primaryContactMethod;
            OtherContactMethods = otherContactMethod;
        }

        public Guid Id { get; }
        public NonEmptyString FirstName { get; }
        public NonEmptyString LastName { get; }
        public Maybe<NonEmptyString> TwitterProfileUrl { get; }
        public Maybe<DateTime> DateOfBirth { get; }
        public ContactMethod PrimaryContactMethod { get; }
        public IEnumerable<ContactMethod> OtherContactMethods { get; }
    }
}