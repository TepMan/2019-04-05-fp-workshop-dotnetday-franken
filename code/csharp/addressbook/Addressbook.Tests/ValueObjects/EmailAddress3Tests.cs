<<<<<<< HEAD:code/csharp/addressbook/Addressbook.Tests/ValueObjects/EmailAddress3Tests.cs
using System;
using DemoCsharp.Addressbook.ValueObjects;
=======
using ContactList.ValueObjects;
>>>>>>> martin sagt, dass ist ok:code/csharp/contact-list/ContactList.Tests/ValueObjects/EmailAddress3Tests.cs
using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace DemoCsharp.Addressbook.Tests.ValueObjects
{
    public class EmailAddress3Tests
    {
        [Theory]
        [InlineData(true, "foo@bar.com", "foo@bar.com")]
        [InlineData(false, "foo@bar.com", "foo@bar.com_x")]
        [InlineData(false, "foo@bar.com", "")]
        [InlineData(false, "foo@bar.com", (string) null)]
        public void Email_extension_handles_input_as_expected(bool shouldPass, string input, string other)
        {
            var result = EmailAddress2.Create(input);

            if (shouldPass)
                result.Should().BeEqualToEmailString(other);
            else
                result.Should().NotBeEqualToEmailString(other);
        }

        [Fact]
        public void Valid_email_is_ok()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            var result = EmailAddress2.Create(validEmail);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeOfType<Maybe<EmailAddress2>>();

            result.Value.Value.Should().Be(validEmail);

            var isOkAndHasValue =
                result.IsOkAndHasValue(EmailAddress2.Create(validEmail).Value);

            isOkAndHasValue.Should().BeTrue();
        }

        [Fact]
        public void Valid_email_is_ok_using_own_extension()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            var result = EmailAddress2.Create(validEmail);

            // Assert
            result.Should().BeEqualToEmailString(validEmail);
        }
    }
}