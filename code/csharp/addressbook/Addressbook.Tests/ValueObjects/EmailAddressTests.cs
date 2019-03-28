using Addressbook.Tests.ValueObjects.TestExtensions;
using Addressbook.ValueObjects;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class EmailAddressTests
    {
        [Fact]
        public void Valid_email_has_correct_value()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            var result = EmailAddress.CreateInternalValidation(validEmail);

            // Assert
            result.Match(
                () => true.Should().BeFalse(),
                x => x.Value.Should().Be("foo@bar.de"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("invalid")]
        public void Empty_string_or_null_or_invalid_becomes_error(string input)
        {
            // Act
            var result = EmailAddress.CreateInternalValidation(input);

            // Assert
            result.Should().BeOfType<Option<EmailAddress>>();
            result.Match(
                () => true.Should().BeTrue(),
                x => x.Should().BeNull());
        }

        [Theory]
        [InlineData("foo@bar.com", "foo@bar.com", true)]
        [InlineData("foo@bar.com", "foo@bar.com_x", false)]
        [InlineData("foo@bar.com", "", false)]
        [InlineData("foo@bar.com", (string) null, false)]
        public void Email_extension_handles_input_as_expected(string input, string other, bool shouldPass)
        {
            var result = EmailAddress.CreateInternalValidation(input);

            if (shouldPass)
                result.Should().BeEqualToEmailString(other);
            else
                result.Should().NotBeEqualToEmailString(other);
        }

        [Theory(Skip = "TODO")]
        [InlineData("foo@bar.com", "foo@bar.com", true)]
        [InlineData("foo@bar.com", "foo@bar.com_x", false)]
        [InlineData("foo@bar.com", "", false)]
        [InlineData("foo@bar.com", (string) null, false)]
        public void EmailFP_extension_handles_input_as_expected(string input, string other, bool shouldPass)
        {
            // TODO
        }
    }
}