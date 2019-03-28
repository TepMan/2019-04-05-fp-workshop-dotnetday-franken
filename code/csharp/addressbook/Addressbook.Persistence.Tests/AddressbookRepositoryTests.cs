using System;
using Addressbook.ValueObjects;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;

namespace Addressbook.Persistence.Tests
{
    public class AddressbookRepositoryTests
    {
        private const string ADDRESSBOOK_JSON = @"/home/patrick/Documents/talks/2019-04-05-fp-workshop-dotnetday-franken/code/csharp/addressbook/Addressbook.Persistence/Data/addressbook.json";

        [Fact(Skip = "TODO Fix path")]
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

        private static AddressbookOO CreateAddressbook()
        {
            var firstname = NonEmptyStringOO.CreateBang("Homer");
            var lastname = NonEmptyStringOO.CreateBang("Simpson");
            var id = Guid.NewGuid();
            var dob = F.Some(new DateTime(1956, 5, 12));
            var twitterProfileUrl = NonEmptyStringOO.Create("https://twitter.com/homerjsimpson");

            var address = F.None;
            
            var contact = new ContactOO(
                id,
                firstname,
                lastname,
                dob,
                twitterProfileUrl,
                address,
                new EmailContact());

            var addressbook = new AddressbookOO();
            addressbook.AddContact(contact);
            return addressbook;
        }
    }
}