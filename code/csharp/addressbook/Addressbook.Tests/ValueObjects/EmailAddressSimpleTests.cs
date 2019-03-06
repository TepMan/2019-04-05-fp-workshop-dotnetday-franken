using System;
using Addressbook.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class EmailAddressSimpleTests
    {
        [Fact]
        public void Invalid_email_throws()
        {
            // Arrange
            var invalidEmail = "invalid";

            // Act
            Action action = () => new EmailAddressSimple(invalidEmail);

            // Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Valid_email_has_correct_value()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            string result = new EmailAddressSimple(validEmail);

            // Assert
            result.Should().Be(validEmail);
        }
    }
}