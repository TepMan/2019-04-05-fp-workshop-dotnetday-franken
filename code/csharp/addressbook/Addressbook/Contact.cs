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
            NonEmptyStringOO firstname,
            NonEmptyStringOO lastname,
            Option<DateTime> dateOfBirth,
            Option<NonEmptyStringOO> twitterProfileUrl,
            Option<AddressOO> address,
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
        public NonEmptyStringOO FirstName { get; private set; }
        public NonEmptyStringOO LastName { get; private set; }
        public Option<NonEmptyStringOO> TwitterProfileUrl { get; private set; }
        public Option<DateTime> DateOfBirth { get; private set; }
        public ContactMethod ContactMethod { get; }
        public Option<AddressOO> Address { get; private set; }
        
        public Contact ChangeFirstName(Option<NonEmptyStringOO> optFirstName)
        {
            optFirstName.Match(
                () => Unit(),
                fn => FirstName = fn);
            
            return this;
        }
        
        public Contact ChangeLastName(Option<NonEmptyStringOO> optLastName)
        {
            optLastName.Match(
                () => Unit(),
                ln => LastName = ln);
            
            return this;
        }
        
        public Contact ChangeTwitterUrl(Option<NonEmptyStringOO> optTwitterUrl)
        {
            TwitterProfileUrl = optTwitterUrl;
            return this;
        }

        public Contact ChangeDateOfBirth(Option<DateTime> optDateOfBirth)
        {
            DateOfBirth = optDateOfBirth;
            return this;
        }

        public Contact ChangeAddress(Option<AddressOO> optAddress)
        {
            Address = optAddress;
            return this;
        }
    }
}