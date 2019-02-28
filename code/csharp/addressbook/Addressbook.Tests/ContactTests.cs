using System;
using System.Collections.Generic;
using Addressbook.ValueObjects;
using FluentAssertions;
using Xunit;
using static LaYumba.Functional.F;


namespace Addressbook.Tests
{
    public class ContactTests
    {
        [Fact]
        public void Creating_a_new_contact_happy_path()
        {
            var firstname = NonEmptyString.CreateBang("Homer");
            var lastname = NonEmptyString.CreateBang("Simpson");

            var id = Guid.NewGuid();

            var dateOfBirth = new DateTime(1956, 5, 12);
            var dob = Some(dateOfBirth);

            var twitterProfileUrl = NonEmptyString.Create("https://twitter.com/homerjsimpson");

            var contact = new Contact(id, firstname, lastname,
                dob, twitterProfileUrl, new EmailContact(), new List<ContactMethod>());

            contact.FirstName.Value.Should().Be("Homer");
            contact.LastName.Value.Should().Be("Simpson");
            contact.DateOfBirth.Should().BeEquivalentTo(Some(new DateTime(1956, 5, 12)));
            contact.TwitterProfileUrl.Should()
                .BeEquivalentTo(Some(NonEmptyString.CreateBang("https://twitter.com/homerjsimpson")));
            contact.PrimaryContactMethod.Should().BeOfType<EmailContact>();
            contact.OtherContactMethods.Should().NotBeNull().And.BeEmpty();
        }
    }
}