using FluentAssertions;
using Xunit;

namespace AddressBook.Tests
{
    public class Tests
    {
        [Fact]
        public void SmokeTest()
        {
            true.Should().BeTrue();
            new Class1().SayHello("test").Should().Be("Hello, test!");
        }
    }
}