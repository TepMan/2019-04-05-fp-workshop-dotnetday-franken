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

        [Fact]
        public void Valid_email_is_ok_using_own_extension_fails()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            var result = EmailAddress2.Create(validEmail);

            // Assert
            // Red test:
            // result.Should().BeEqualToEmailString(validEmail + "_Foo", "I am Chuck Norris");            
            //
            // Green test:
            result.Should().BeEqualToEmailString(validEmail);            
        }
    }
}