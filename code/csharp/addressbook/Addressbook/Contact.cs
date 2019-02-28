using System;
using System.Collections.Generic;
using Addressbook.ValueObjects;
using LaYumba.Functional;

using static LaYumba.Functional.F;

namespace Addressbook
{
    // Mmh, not sure yet if this class should also be a Value Object...
    public class Contact
    {
        public Contact(Guid id,
            NonEmptyString firstname,
            NonEmptyString lastname,
            Option<DateTime> dateOfBirth,
            Option<NonEmptyString> twitterProfileUrl,
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
        public Option<NonEmptyString> TwitterProfileUrl { get; }
        public Option<DateTime> DateOfBirth { get; }
        public ContactMethod PrimaryContactMethod { get; }
        public IEnumerable<ContactMethod> OtherContactMethods { get; }

        // TODO Add an actual address ;-)
    }
}