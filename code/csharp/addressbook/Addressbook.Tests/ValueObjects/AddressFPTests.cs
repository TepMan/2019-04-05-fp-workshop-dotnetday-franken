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
    }
}