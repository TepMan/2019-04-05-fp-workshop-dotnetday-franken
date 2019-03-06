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
            var contact = CreateHomer();

            contact.FirstName.Value.Should().Be("Homer");
            contact.LastName.Value.Should().Be("Simpson");
            contact.DateOfBirth.Should().BeEquivalentTo(Some(new DateTime(1956, 5, 12)));
            contact.TwitterProfileUrl.Should()
                .BeEquivalentTo(Some(NonEmptyString.CreateBang("https://twitter.com/homerjsimpson")));
            contact.PrimaryContactMethod.Should().BeOfType<EmailContact>();
            contact.OtherContactMethods.Should().NotBeNull().And.BeEmpty();
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
                .ChangeFirstName(NonEmptyString.Create(newFirstName))
                .ChangeLastName(NonEmptyString.Create(newLastName));
            
            // Assert
            result.FirstName.Value.Should().Be(isFirstNameValid ? newFirstName : contact.FirstName.Value);
            result.LastName.Value.Should().Be(isLastNameValid ? newLastName : contact.LastName.Value);
            result.Id.Should().Be(contact.Id);
        }
        
        
        private static Contact CreateHomer()
        {
            var firstname = NonEmptyString.CreateBang("Homer");
            var lastname = NonEmptyString.CreateBang("Simpson");

            var id = Guid.NewGuid();

            var dateOfBirth = new DateTime(1956, 5, 12);
            var dob = Some(dateOfBirth);

            var twitterProfileUrl = NonEmptyString.Create("https://twitter.com/homerjsimpson");

            var contact = new Contact(id, firstname, lastname,
                dob, twitterProfileUrl, new EmailContact(), new List<ContactMethod>());
            return contact;
        }
    }
}