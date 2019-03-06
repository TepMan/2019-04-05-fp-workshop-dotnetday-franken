using System;
using System.Collections.Generic;
using Addressbook.ValueObjects;
using LaYumba.Functional;

using static LaYumba.Functional.F;

namespace Addressbook
{
    // Mmh, not sure yet if this class should also be a Value Object...
    // Probably not, because this object has an identity, and therefore is an entity (not a value object)
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
        public NonEmptyString FirstName { get; private set; }
        public NonEmptyString LastName { get; private set; }
        public Option<NonEmptyString> TwitterProfileUrl { get; }
        public Option<DateTime> DateOfBirth { get; }
        public ContactMethod PrimaryContactMethod { get; }
        public IEnumerable<ContactMethod> OtherContactMethods { get; }


        public Contact ChangeFirstName(Option<NonEmptyString> optFirstName)
        {
            optFirstName.Match(
                () => Unit(),
                fn => FirstName = fn);
            
            return this;
        }
        
        public Contact ChangeLastName(Option<NonEmptyString> optLastName)
        {
            optLastName.Match(
                () => Unit(),
                fn => LastName = fn);
            
            return this;
        }
        
        // TODO Add an actual address ;-)
    }
}