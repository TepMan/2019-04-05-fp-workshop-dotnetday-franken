using System;
using Addressbook.ValueObjects;
using LaYumba.Functional;

namespace Addressbook.Persistence.Dtos
{
    public class ContactDto
    {
        public Guid Id { get; set;  }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Option<string> TwitterProfileUrl { get; set; }
        public Option<DateTime> DateOfBirth { get; set; }
        public ContactMethod ContactMethod { get; set; }
        public Option<AddressOO> Address { get; set; }
    }
}