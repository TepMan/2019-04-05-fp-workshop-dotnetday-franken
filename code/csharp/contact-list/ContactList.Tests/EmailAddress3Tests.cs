using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace ContactList.Tests
{
    public class EmailAddress3Tests
    {
        [Fact]
        public void Valid_email_is_ok()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            var result = EmailAddress2.Create(validEmail);

            // Assert
            // result.HasExpectedEmail(validEmail).Should().BeTrue();
            result.IsOkAndHasValue<EmailAddress2>(EmailAddress2.Create(validEmail).Value).Should().BeTrue();
        }
    }
}