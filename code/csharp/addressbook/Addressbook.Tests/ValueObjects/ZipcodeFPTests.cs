using Addressbook.ValueObjects;
using FluentAssertions;
using FluentAssertions.Primitives;
using LaYumba.Functional;
using LaYumba.Functional.Option;
using Xunit;
using static Addressbook.Tests.ValueObjects.AssertionHelper;

namespace Addressbook.Tests.ValueObjects
{
    public class ZipcodeFPTests
    {
        [Theory]
        [InlineData("123", true)]
        [InlineData("abc ", true)]
        [InlineData("x", false)]
        public void Creating_a_zipcode_from_NonEmptyString_works(string input, bool isValid)
        {
            var result = ZipcodeFP.Create(NonEmptyStringFP.Create(input));
            if (isValid)
            {
                result.Match(
                    NoneFails,
                    x => x.ToString().Should().Be(input));
            }
            else
            {
                result.Match(
                    NoneIsTrue,
                    x => x.ToString().Should().NotBe(input));
            }
        }

        [Fact]
        public void Creating_a_zipcode_from_None_works()
        {
            var result = ZipcodeFP.Create(F.None);
            result.Match(
                () => NoneIsTrue(),
                x => false.Should().BeTrue());
        }

    }
}