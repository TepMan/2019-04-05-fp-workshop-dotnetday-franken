using Addressbook.ValueObjects;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class EmailAddress3Tests
    {
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