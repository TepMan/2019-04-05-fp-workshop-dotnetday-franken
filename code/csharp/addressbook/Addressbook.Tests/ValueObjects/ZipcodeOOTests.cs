using System;
using Addressbook.ValueObjects;
using FluentAssertions;
using FluentAssertions.Primitives;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    // TODO Error messages are still crappy!
    public class ZipcodeOOTests
    {
        [Theory]
        [InlineData("123", true)]
        [InlineData("abc", true)]
        [InlineData("x", false)]
        public void Creating_a_zipcode_from_NonEmptyString_works(string input, bool isValid)
        {
            var result = ZipcodeOO.Create(NonEmptyStringOO.CreateBang(input));
            if (isValid)
            {
                result.Match(
                    AssertionHelper.NoneFails,
                    SomeWithStringValueShouldBe(input));
            }
            else
            {
                result.Match(
                    AssertionHelper.NoneIsTrue,
                    SomeWithStringValueShouldFail());
            }
        }

        [Theory]
        [InlineData("123", true)]
        [InlineData("abc", true)]
        [InlineData("x", false)]
        public void Creating_a_zipcode_from_string_works(string input, bool isValid)
        {
            var result = ZipcodeOO.Create(input);
            if (isValid)
            {
                result.Match(
                    AssertionHelper.NoneFails,
                    SomeWithStringValueShouldBe(input));
            }
            else
            {
                result.Match(
                    AssertionHelper.NoneIsTrue,
                    SomeWithStringValueShouldFail());
            }
        }

        private static Func<ZipcodeOO, AndConstraint<StringAssertions>> SomeWithStringValueShouldBe
            (string input) => x => x.Value.Should().Be(input);

        private static Func<ZipcodeOO, AndConstraint<StringAssertions>> SomeWithStringValueShouldFail
            () => x => x.Value.Should().Be("ups");
    }
}