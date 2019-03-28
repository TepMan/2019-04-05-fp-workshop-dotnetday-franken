using Addressbook.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class AddressFPTests
    {
        [Fact]
        public void Creating_address_works()
        {
            // Act
            var addressFP = AddressFP.CreateValidAddress("742 Evergreen Terrace", "Springfield", "58008");

            // Assert
            addressFP.IsValid.Should().BeTrue();
            addressFP.ToString().Should().Be("Valid(Street: 742 Evergreen Terrace; City: Springfield; Zipcode: 58008)");
        }

        [Theory]
        [InlineData("",            "",          "",             "Invalid([Invalid street: '', Invalid city: '', Invalid zipcode: ''])")]
        [InlineData("validStreet", "",          "",             "Invalid([Invalid city: '', Invalid zipcode: ''])")]
        [InlineData("validStreet", "validCity", "",             "Invalid([Invalid zipcode: ''])")]
        [InlineData("validStreet", "",          "validZipcode", "Invalid([Invalid city: ''])")]
        [InlineData("",            "validCity", "validZipcode", "Invalid([Invalid street: ''])")]
        [InlineData("",            "validCity", "",             "Invalid([Invalid street: '', Invalid zipcode: ''])")]
        [InlineData("",            "",          "validZipcode", "Invalid([Invalid street: '', Invalid city: ''])")]
        public void Creating_address_handles_invalid_input(string street, string city, string zipcode, string expected)
        {
            var result = AddressFP.CreateValidAddress(street, city, zipcode);
            result.IsValid.Should().BeFalse();
            result.ToString().Should().Be(expected);

        }
    }
}