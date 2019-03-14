using System;
using System.Collections.Generic;
using Addressbook.ValueObjects;
using FluentAssertions;
using Xunit;
using static LaYumba.Functional.F;

namespace Addressbook.Tests
{
    public class AddressbookTests
    {
        [Fact]
        public void Adding_new_contact_works()
        {
            var firstname = NonEmptyString.CreateBang("Homer");
            var lastname = NonEmptyString.CreateBang("Simpson");
            var id = Guid.NewGuid();
            var dob = Some(new DateTime(1956, 5, 12));
            var twitterProfileUrl = NonEmptyString.Create("https://twitter.com/homerjsimpson");
            var address = None;
            
            var contact = new Contact(
                id,
                firstname,
                lastname,
                dob,
                twitterProfileUrl,
                address,
                new EmailContact());

            var sut = new Addressbook();

            // important design decision: do we have state in Addressbook or not?
            // should the following code return a modified list or have internal state?
            //
            // with state
            sut.Contacts.Should().BeEmpty();
            sut.AddContact(contact);
            sut.Contacts.Should().HaveCount(1, "we added one contact");
        }
    }
}