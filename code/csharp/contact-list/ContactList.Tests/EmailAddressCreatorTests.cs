using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace ContactList.Tests
{
    public class EmailAddressCreatorTests
    {
        [Fact]
        public void Valid_email_is_ok()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            var result = EmailAddressCreator.CreateFrom(validEmail);

            // Assert
            result.Should().BeOfType<Maybe<EmailAddress>>();
            result.HasValue.Should().BeTrue();

            // 1st "Value" is from Maybe, 2nd "Value" is content of EmailAddress
            result.Value.Value.Should().Be(validEmail); 
        }

        [Fact]
        public void Empty_string_returns_error()
        {
            // Arrange
            var emptyString = string.Empty;

            // Act
            var result = EmailAddressCreator.CreateFrom(emptyString);

            // Assert
            result.Should().BeOfType<Maybe<EmailAddress>>();
            result.HasNoValue.Should().BeTrue();
        }
    }
}