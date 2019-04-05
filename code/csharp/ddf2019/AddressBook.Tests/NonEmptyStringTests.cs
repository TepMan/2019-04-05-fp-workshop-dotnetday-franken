using System;
using FluentAssertions;
using NSubstitute.Core;
using Xunit;

namespace AddressBook.Tests
{
    public class NonEmptyStringTests
    {
        [Fact]
        public void CreatingNonEmptyStringWorks()
        {
            var nonEmptyString = new NonEmptyString("a");
            nonEmptyString.Value.Should().Be("a");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreatingNonEmptyThrowsWhenStringIsEmpty(string input)
        {
            Action act = () => new NonEmptyString(input);
            act.Should().Throw<ArgumentException>();
        }
    }
}