using Addressbook.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class AddressTests
    {
        [Fact]
        public void Two_addresses_with_same_content_are_equal()
        {
            var zipCode = ZipcodeOO.CreateBang("12345");
            var street = NonEmptyStringOO.CreateBang("742 Evergreen Terrace");
            var city = NonEmptyStringOO.CreateBang("Springfield");

            var address1 = Address.CreateClassic(street, city, zipCode);
            var address2 = Address.CreateClassic(street, city, zipCode);
            
            address1.Should().Be(address2);
        }

        [Fact]
        public void Two_addresses_with_different_content_are_not_equal()
        {
            var zipCode = ZipcodeOO.CreateBang("12345");
            var street = NonEmptyStringOO.CreateBang("742 Evergreen Terrace");
            var city1 = NonEmptyStringOO.CreateBang("Springfield");
            var city2 = NonEmptyStringOO.CreateBang("Shelbyville");

            var address1 = Address.CreateClassic(street, city1, zipCode);
            var address2 = Address.CreateClassic(street, city2, zipCode);
            
            address1.Should().NotBe(address2);
        }
    }
}