using System;
using DemoCsharp.Addressbook.ValueObjects;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace DemoCsharp.Addressbook.Tests.ValueObjects
{
    public class EmailAddress2Tests
    {
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

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("invalid", false)]
        [InlineData("a@b.c", true)]
        public void CreateBang_returns_correct_result(string input, bool isValid)
        {
            if (isValid)
            {
                var result = EmailAddress2.CreateBang(input);
            }
            else
            {
                Action action = () => EmailAddress2.CreateBang(input);
                action.Should().Throw<ArgumentException>().WithMessage($"Invalid email address: {input}");
            }
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
    }
}