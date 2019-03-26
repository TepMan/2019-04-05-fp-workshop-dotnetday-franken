using System;
using System.Collections.Generic;
using Addressbook.ValueObjects;
using LaYumba.Functional;

using static LaYumba.Functional.F;

namespace Addressbook
{
    
    public class ContactOO
    {
        public ContactOO(Guid id,
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
        
        public ContactOO ChangeFirstName(Option<NonEmptyStringOO> optFirstName)
        {
            optFirstName.Match(
                () => Unit(),
                fn => FirstName = fn);
            
            return this;
        }
        
        public ContactOO ChangeLastName(Option<NonEmptyStringOO> optLastName)
        {
            optLastName.Match(
                () => Unit(),
                ln => LastName = ln);
            
            return this;
        }
        
        public ContactOO ChangeTwitterUrl(Option<NonEmptyStringOO> optTwitterUrl)
        {
            TwitterProfileUrl = optTwitterUrl;
            return this;
        }

        public ContactOO ChangeDateOfBirth(Option<DateTime> optDateOfBirth)
        {
            DateOfBirth = optDateOfBirth;
            return this;
        }

        public ContactOO ChangeAddress(Option<AddressOO> optAddress)
        {
            Address = optAddress;
            return this;
        }
    }
}