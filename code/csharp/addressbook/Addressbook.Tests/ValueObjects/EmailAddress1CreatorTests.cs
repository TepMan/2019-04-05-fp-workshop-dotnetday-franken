using Addressbook.ValueObjetcs;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class EmailAddress1CreatorTests
    {
        [Fact]
        public void Empty_string_returns_error()
        {
            // Arrange
            var emptyString = string.Empty;

            // Act
            var result = EmailAddress1Creator.CreateFrom(emptyString);

            // Assert
            result.Should().BeOfType<Maybe<EmailAddress1>>();
            result.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Valid_email_is_ok()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            var result = EmailAddress1Creator.CreateFrom(validEmail);

            // Assert
            result.Should().BeOfType<Maybe<EmailAddress1>>();
            result.HasValue.Should().BeTrue();

            // 1st "Value" is from Maybe, 2nd "Value" is content of EmailAddress
            result.Value.Value.Should().Be(validEmail);
        }
    }
}