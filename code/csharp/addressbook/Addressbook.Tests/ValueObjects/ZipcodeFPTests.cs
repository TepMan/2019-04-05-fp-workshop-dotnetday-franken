using Addressbook.ValueObjects;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;
using static Addressbook.Tests.ValueObjects.AssertionHelper;
using static LaYumba.Functional.F;
using System;

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
            var result = ZipcodeFP.Create(None);
            result.Match(
                () => NoneIsTrue(),
                x => false.Should().BeTrue());
        }

        [Fact]
        public void Mapping_Option_of_DateTime_works()
        {
            var optDt = Some(DateTime.Now);
            optDt.Map(toDate).Should().NotBeNull();
        }

        private DateTime toDate(DateTime dt) => dt.Date;

    }
}