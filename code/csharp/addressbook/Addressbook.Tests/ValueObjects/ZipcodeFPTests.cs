using System;
using Addressbook.ValueObjects;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class ZipcodeFPTests
    {
        [Theory]
        [InlineData("123", true)]
        [InlineData("abc ", true)]
        [InlineData("x", false)]
        [InlineData("xy", false)]
        public void Creating_a_zipcode_from_NonEmptyString_works(string input, bool isValid)
        {
            var result = ZipcodeFP.Create(NonEmptyStringFP.Create(input));
            if (isValid)
            {
                result.Match(
                    AssertionHelper.NoneFails,
                    x => x.ToString().Should().Be(input));
            }
            else
            {
                result.Match(
                    AssertionHelper.NoneIsTrue,
                    x => x.ToString().Should().NotBe(input));
            }
        }

        [Fact]
        public void Creating_a_zipcode_from_None_works()
        {
            var result = ZipcodeFP.Create(F.None);
            result.Match(
                () => AssertionHelper.NoneIsTrue(),
                x => false.Should().BeTrue());
        }

        [Fact]
        public void Mapping_Option_of_DateTime_works()
        {
            var optDt = F.Some(DateTime.Now);
            optDt.Map(toDate).Should().NotBeNull();
        }

        private DateTime toDate(DateTime dt) => dt.Date;

    }
}