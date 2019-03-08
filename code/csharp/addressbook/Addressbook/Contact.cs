using System;
using System.Collections.Generic;
using Addressbook.ValueObjects;
using LaYumba.Functional;

using static LaYumba.Functional.F;

namespace Addressbook
{
    // Mmh, not sure yet if this class should also be a Value Object...
    // Probably not, because this object has an identity, and therefore is an entity (not a value object)
    
    // TODO Add an actual address ;-)
    [Serializable]
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
        public Option<NonEmptyString> TwitterProfileUrl { get; private set; }
        public Option<DateTime> DateOfBirth { get; private set; }
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
                ln => LastName = ln);
            
            return this;
        }
        
        public Contact ChangeTwitterUrl(Option<NonEmptyString> optTwitterUrl)
        {
            TwitterProfileUrl = optTwitterUrl;
            return this;
        }

        public Contact ChangeDateOfBirth(Option<DateTime> optDateOfBirth)
        {
            DateOfBirth = optDateOfBirth;
            return this;
        }
    }
}