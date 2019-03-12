using System;
using Addressbook.ValueObjects;
using FluentAssertions;
using FluentAssertions.Primitives;
using Xunit;
using static Addressbook.Tests.ValueObjects.AssertionHelper;

namespace Addressbook.Tests.ValueObjects
{
    // TODO Error messages are still crappy!
    public class ZipcodeTests
    {
        [Theory]
        [InlineData("123", true)]
        [InlineData("abc", true)]
        [InlineData("invalid", false)]
        public void Creating_a_zipcode_from_NonEmptyString_works(string input, bool isValid)
        {
            var result = Zipcode.Create(NonEmptyString.CreateBang(input));
            if (isValid)
            {
                result.Match(
                    NoneFails,
                    SomeWithStringValueShouldBe(input));
            }
            else
            {
                result.Match(
                    NoneIsTrue,
                    SomeWithStringValueShouldFail());
            }
        }

        [Theory]
        [InlineData("123", true)]
        [InlineData("abc", true)]
        [InlineData("invalid", false)]
        public void Creating_a_zipcode_from_string_works(string input, bool isValid)
        {
            var result = Zipcode.Create(input);
            if (isValid)
            {
                result.Match(
                    NoneFails,
                    SomeWithStringValueShouldBe(input));
            }
            else
            {
                result.Match(
                    NoneIsTrue,
                    SomeWithStringValueShouldFail());
            }
        }

        private static Func<Zipcode, AndConstraint<StringAssertions>> SomeWithStringValueShouldBe
            (string input) => x => x.Value.Should().Be(input);

        private static Func<Zipcode, AndConstraint<StringAssertions>> SomeWithStringValueShouldFail
            () => x => x.Value.Should().Be("ups");
    }
}