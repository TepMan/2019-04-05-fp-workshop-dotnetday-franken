using Addressbook.ValueObjects;
using LaYumba.Functional;
using static LaYumba.Functional.F;
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
            result.Should().BeOfType<Option<EmailAddress1>>();
            //result.Should().BeEquivalentTo(None);
            result.Match(
                () => true.Should().BeTrue(),
                x => x.Should().BeNull());
        }

        [Fact]
        public void Valid_email_is_ok()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            var result = EmailAddress1Creator.CreateFrom(validEmail);

            // Assert
            result.Should().BeOfType<Option<EmailAddress1>>();
            //result.Should().BeEquivalentTo(EmailAddress1Creator.CreateFrom(validEmail));
            //result.Match(
            //    () => true.Should().BeFalse(),
            //    x => x.Should().Be(validEmail));

        }
    }
}