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
            Option<Address> address,
            ContactMethod contactMethod)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateOfBirth;
            TwitterProfileUrl = twitterProfileUrl;
            Address = address;
            ContactMethod = contactMethod;
        }

        public Guid Id { get; }
        public NonEmptyString FirstName { get; private set; }
        public NonEmptyString LastName { get; private set; }
        public Option<NonEmptyString> TwitterProfileUrl { get; private set; }
        public Option<DateTime> DateOfBirth { get; private set; }
        public ContactMethod ContactMethod { get; }
        public Option<Address> Address { get; private set; }
        
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

        public Contact ChangeAddress(Option<Address> optAddress)
        {
            Address = optAddress;
            return this;
        }
    }
}