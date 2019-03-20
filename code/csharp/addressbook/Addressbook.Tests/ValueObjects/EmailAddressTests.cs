using System;
using Addressbook.ValueObjects;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;
using Addressbook.Tests.ValueObjects.TestExtensions;

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
            var result = EmailAddress.Create(validEmail);

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
            var result = EmailAddress.Create(input);

            // Assert
            result.Should().BeOfType<Option<EmailAddress>>();
            result.Match(
                () => true.Should().BeTrue(),
                x => x.Should().BeNull());
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("invalid", false)]
        [InlineData("a@b.c", true)]
        public void CreateBang_returns_correct_result(string input, bool isValid)
        {
            if (isValid)
            {
                var result = EmailAddress.CreateBang(input);
            }
            else
            {
                Action action = () => EmailAddress.CreateBang(input);
                action.Should().Throw<ArgumentException>().WithMessage($"Invalid email address: {input}");
            }
        }

        [Theory]
        [InlineData(true, "foo@bar.com", "foo@bar.com")]
        [InlineData(false, "foo@bar.com", "foo@bar.com_x")]
        [InlineData(false, "foo@bar.com", "")]
        [InlineData(false, "foo@bar.com", (string) null)]
        public void Email_extension_handles_input_as_expected(bool shouldPass, string input, string other)
        {
            var result = EmailAddress.Create(input);

            if (shouldPass)
                result.Should().BeEqualToEmailString(other);
            else
                result.Should().NotBeEqualToEmailString(other);
        }
    }
}