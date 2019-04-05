using System;
using FluentAssertions;
using NSubstitute.Core;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using Xunit;

namespace AddressBook.Tests
{
    public class NonEmptyStringTests
    {
        [Fact]
        public void CreatingNonEmptyStringWorks()
        {
            var optNonEmptyString = NonEmptyString.Create("a");
            optNonEmptyString.Match(
                () => true.Should().BeFalse(),
                x=>x.Value.Should().Be("a"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreatingNonEmptyThrowsWhenStringIsEmpty(string input)
        {
            var optNonEmptyString = NonEmptyString.Create(input);
            optNonEmptyString.Match(
                () => true.Should().BeTrue(),
                x=>x.Value.Should().Be(""));
        }

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //public void CreatingNonEmptyThrowsWhenStringIsEmpty(string input)
        //{
        //    Action act = () => NonEmptyString.Create(input);
        //    act.Should().Throw<ArgumentException>();
        //}
    }
}