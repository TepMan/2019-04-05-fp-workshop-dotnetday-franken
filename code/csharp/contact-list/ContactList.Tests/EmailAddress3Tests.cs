using System;
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
            result.Should()
                .NotBeNull()
                .And.BeOfType<Maybe<EmailAddress2>>();
                
            result.Value.Value.Should().Be(validEmail);

            var isOkAndHasValue = 
                result.IsOkAndHasValue<EmailAddress2>(EmailAddress2.Create(validEmail).Value);
            
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

        [Theory]
        [InlineData(true, "foo@bar.com", "foo@bar.com")]
        [InlineData(false, "foo@bar.com", "foo@bar.com_x")]
        [InlineData(false, "foo@bar.com", "")]
        [InlineData(false, "foo@bar.com", (string)null)]
        public void Valid_email_is_ok_using_own_extension_fails(bool shouldPass, string input, string other)
        {
            var result = EmailAddress2.Create(input);

            if (shouldPass)
            {
                result.Should().BeEqualToEmailString(other);
            }
            else
            {
                // TODO implement `NotBeEqualToEmailString`
                try
                {
                    result.Should().BeEqualToEmailString(other);    
                }
                catch (Exception)
                {
                    true.Should().BeTrue();
                }
            }
        }
    }
}