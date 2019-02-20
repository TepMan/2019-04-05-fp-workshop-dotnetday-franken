using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace ContactList.Tests
{
    public class EmailAddress2Tests
    {
        [Fact]
        public void Valid_email_is_ok()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            var result = EmailAddress2.Create(validEmail);

            // Assert
            result.Should().BeOfType<Maybe<EmailAddress2>>();
            result.HasValue.Should().BeTrue();
        }

        [Fact]
        public void Valid_email_has_correct_value()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            var result = EmailAddress2.Create(validEmail);

            // Assert
            result.Value.Value.Should().Be(validEmail);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("invalid")]
        public void Empty_string_or_null_or_invalid_becomes_error(string input)
        {
            // Act
            var result = EmailAddress2.Create(input);

            // Assert
            result.Should().BeOfType<Maybe<EmailAddress2>>();
            result.HasNoValue.Should().BeTrue();
        }
    }
}