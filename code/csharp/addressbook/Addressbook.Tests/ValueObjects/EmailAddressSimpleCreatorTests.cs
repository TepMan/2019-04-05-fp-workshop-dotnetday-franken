using Addressbook.ValueObjects;
using LaYumba.Functional;

using FluentAssertions;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class EmailAddressSimpleCreatorTests
    {
        [Fact]
        public void Empty_string_returns_error()
        {
            // Arrange
            var emptyString = string.Empty;

            // Act
            var result = EmailAddressSimpleCreator.CreateFrom(emptyString);

            // Assert
            result.Should().BeOfType<Option<EmailAddressSimple>>();
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
            var result = EmailAddressSimpleCreator.CreateFrom(validEmail);

            // Assert
            result.Should().BeOfType<Option<EmailAddressSimple>>();
            //result.Should().BeEquivalentTo(EmailAddressSimpleCreator.CreateFrom(validEmail));
            //result.Match(
            //    () => true.Should().BeFalse(),
            //    x => x.Should().Be(validEmail));

        }
    }
}