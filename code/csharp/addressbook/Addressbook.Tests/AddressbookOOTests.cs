using System;
using Addressbook.ValueObjects;
using FluentAssertions;
using Xunit;
using static LaYumba.Functional.F;

namespace Addressbook.Tests
{
    public class AddressbookOOTests
    {
        [Fact]
        public void Adding_new_contact_works()
        {
            var firstname = NonEmptyStringOO.CreateBang("Homer");
            var lastname = NonEmptyStringOO.CreateBang("Simpson");
            var id = Guid.NewGuid();
            var dob = Some(new DateTime(1956, 5, 12));
            var twitterProfileUrl = NonEmptyStringOO.Create("https://twitter.com/homerjsimpson");
            var address = None;
            
            var contact = new ContactOO(
                id,
                firstname,
                lastname,
                dob,
                twitterProfileUrl,
                address,
                new EmailContact());

            var sut = new AddressbookOO();

            // important design decision: do we have state in Addressbook or not?
            // should the following code return a modified list or have internal state?
            //
            // with state
            sut.Contacts.Should().BeEmpty();
            sut.AddContact(contact);
            sut.Contacts.Should().HaveCount(1, "we added 1 contact");
        }
    }
}