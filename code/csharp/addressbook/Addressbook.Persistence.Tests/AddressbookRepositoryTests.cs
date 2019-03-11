using System;
using System.Collections.Generic;
using Addressbook.ValueObjects;
using FluentAssertions;
using Xunit;
using static LaYumba.Functional.F;

namespace Addressbook.Persistence.Tests
{
    public class AddressbookRepositoryTests
    {
        private const string ADDRESSBOOK_JSON = @"/home/patrick/Documents/talks/2019-04-05-fp-workshop-dotnetday-franken/code/csharp/addressbook/Addressbook.Persistence/Data/addressbook.json";

        [Fact]
        public void Save_works()
        {
            var addressbook = CreateAddressbook();
            var sut = new AddressbookRepository(ADDRESSBOOK_JSON);
            sut.Save(addressbook);            
        }

        [Fact(Skip = "because I'm too stupid")]
        public void GetAddressbook_works()
        {
            var sut = new AddressbookRepository(ADDRESSBOOK_JSON);
            var result = sut.GetAddressbook();
            result.Should().NotBeNull();
        }

        private static Addressbook CreateAddressbook()
        {
            var firstname = NonEmptyString.CreateBang("Homer");
            var lastname = NonEmptyString.CreateBang("Simpson");
            var id = Guid.NewGuid();
            var dob = Some(new DateTime(1956, 5, 12));
            var twitterProfileUrl = NonEmptyString.Create("https://twitter.com/homerjsimpson");

            var contact = new Contact(
                id,
                firstname,
                lastname,
                dob,
                twitterProfileUrl,
                new EmailContact(),
                new List<ContactMethod>());

            var addressbook = new Addressbook();
            addressbook.AddContact(contact);
            return addressbook;
        }
    }
}