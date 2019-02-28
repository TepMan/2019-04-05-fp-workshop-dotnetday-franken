using System;
using System.Collections.Generic;
using DemoCsharp.Addressbook.ValueObjects;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace DemoCsharp.Addressbook.Tests
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
            var dob = dateOfBirth != null
                ? Maybe<DateTime>.From(dateOfBirth)
                : Maybe<DateTime>.None;

            var twitterProfileUrl = NonEmptyString.Create("https://twitter.com/homerjsimpson");

            var contact = new Contact(id, firstname, lastname,
                dob, twitterProfileUrl, new EmailContact(), new List<ContactMethod>());

            contact.FirstName.Value.Should().Be("Homer");
            contact.LastName.Value.Should().Be("Simpson");
            contact.DateOfBirth.Should().Be(new DateTime(1956, 5, 12));
            contact.TwitterProfileUrl.Value.Value.Should().Be("https://twitter.com/homerjsimpson");
            contact.PrimaryContactMethod.Should().BeOfType<EmailContact>();
            contact.OtherContactMethods.Should().NotBeNull().And.BeEmpty();
        }
    }
}