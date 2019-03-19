using System;
using System.Collections.Generic;
using Addressbook.ValueObjects;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;
using static LaYumba.Functional.F;


namespace Addressbook.Tests
{
    public class ContactTests
    {
        [Fact]
        public void Creating_a_new_contact_happy_path()
        {
            var contact = CreateHomer();

            contact.FirstName.Value.Should().Be("Homer");
            contact.LastName.Value.Should().Be("Simpson");
            contact.DateOfBirth.Should().BeEquivalentTo(Some(new DateTime(1956, 5, 12)));
            contact.TwitterProfileUrl.Should()
                .BeEquivalentTo(Some(NonEmptyString.CreateBang("https://twitter.com/homerjsimpson")));
            contact.ContactMethod.Should().BeOfType<EmailContact>();
        }

        [Theory]
        [InlineData("Lisa", "Flanders", true, true)]
        [InlineData("", "Flanders", false, true)]
        [InlineData("Lisa", "", true, false)]
        public void Changing_name_works_and_does_not_modify_id(
            string newFirstName, string newLastName,
            bool isFirstNameValid, bool isLastNameValid)
        {
            // Arrange
            var contact = CreateHomer();

            // Act
            var result = contact
                .ChangeFirstName(NonEmptyString.CreateClassic(newFirstName))
                .ChangeLastName(NonEmptyString.CreateClassic(newLastName));

            // Assert
            result.FirstName.Value.Should().Be(isFirstNameValid ? newFirstName : contact.FirstName.Value);
            result.LastName.Value.Should().Be(isLastNameValid ? newLastName : contact.LastName.Value);
            result.Id.Should().Be(contact.Id);
        }

        [Theory]
        [InlineData("https://www.google.de", true)]
        [InlineData("", false)]
        public void Changing_optional_twitter_url_works_and_does_not_modify_id(string newTwitterUrl, bool isValid)
        {
            // Arrange
            var contact = CreateHomer();
            var twitterUrl = NonEmptyString.CreateClassic(newTwitterUrl);

            // Act
            var result = contact.ChangeTwitterUrl(twitterUrl);

            // Assert
            result.TwitterProfileUrl.Should().Be(isValid ? twitterUrl : None);
            result.Id.Should().Be(contact.Id);
        }

        [Fact]
        public void Changing_optional_address_works_and_does_not_modify_id()
        {
            // Arrange
            var contact = CreateHomer();
            var address = CreateAddress();
            
            // Act
            var result = contact.ChangeAddress(address);

            // Assert
            result.Address.Should().Be(Some(CreateAddress()));
            result.Id.Should().Be(contact.Id);
        }

        [Theory]
        [InlineData(1980, 1, 1, true)]
        [InlineData(null, null, null, false)]
        public void Changing_optional_date_of_birth_works_and_does_not_modify_id(
            int? year, int? month, int? day, bool isValid)
        {
            // Arrange
            var contact = CreateHomer();
            Option<DateTime> dateOfBirth = None;
            // ReSharper disable PossibleInvalidOperationException
            if (isValid) dateOfBirth = Some(new DateTime(year.Value, month.Value, day.Value));
            // ReSharper restore PossibleInvalidOperationException

            // Act
            var result = contact.ChangeDateOfBirth(isValid ? dateOfBirth : None);

            // Assert
            result.DateOfBirth.Should().Be(isValid ? dateOfBirth : None);
            result.Id.Should().Be(contact.Id);
        }
        
        private static Contact CreateHomer()
        {
            var firstname = NonEmptyString.CreateBang("Homer");
            var lastname = NonEmptyString.CreateBang("Simpson");

            var id = Guid.NewGuid();

            var dateOfBirth = new DateTime(1956, 5, 12);
            var dob = Some(dateOfBirth);

            var twitterProfileUrl = NonEmptyString.CreateClassic("https://twitter.com/homerjsimpson");

            var address = None;
            
            var contact = new Contact(id, firstname, lastname,
                dob, twitterProfileUrl, address, new EmailContact());
            return contact;
        }

        private static Address CreateAddress()
        {
            var zipCode = Zipcode.CreateBang("58008");
            var street = NonEmptyString.CreateBang("742 Evergreen Terrace");
            var city = NonEmptyString.CreateBang("Springfield");

            var address = Address.CreateClassic(street, city, zipCode);
            return address;
        }
    }
}