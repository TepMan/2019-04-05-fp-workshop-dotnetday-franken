using Addressbook.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class AddressOOTests
    {
        [Fact]
        public void Creating_address_works()
        {
            var zipCode = ZipcodeOO.CreateBang("12345");
            var street = NonEmptyStringOO.CreateBang("742 Evergreen Terrace");
            var city = NonEmptyStringOO.CreateBang("Springfield");

            var addressOO = AddressOO.Create(street, city, zipCode);
            addressOO.City.Value.Should().Be("Springfield");
            addressOO.Street.Value.Should().Be("742 Evergreen Terrace");
            addressOO.Zipcode.Value.Should().Be("12345");
        }

        [Fact]
        public void Two_addresses_with_same_content_are_equal()
        {
            var zipCode = ZipcodeOO.CreateBang("12345");
            var street = NonEmptyStringOO.CreateBang("742 Evergreen Terrace");
            var city = NonEmptyStringOO.CreateBang("Springfield");

            var address1 = AddressOO.Create(street, city, zipCode);
            var address2 = AddressOO.Create(street, city, zipCode);
            
            address1.Should().Be(address2);
        }

        [Fact]
        public void Two_addresses_with_different_content_are_not_equal()
        {
            var zipCode = ZipcodeOO.CreateBang("12345");
            var street = NonEmptyStringOO.CreateBang("742 Evergreen Terrace");
            var city1 = NonEmptyStringOO.CreateBang("Springfield");
            var city2 = NonEmptyStringOO.CreateBang("Shelbyville");

            var address1 = AddressOO.Create(street, city1, zipCode);
            var address2 = AddressOO.Create(street, city2, zipCode);
            
            address1.Should().NotBe(address2);
        }
    }
}