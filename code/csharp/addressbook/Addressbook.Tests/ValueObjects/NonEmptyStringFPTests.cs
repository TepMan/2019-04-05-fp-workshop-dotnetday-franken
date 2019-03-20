using System;
using Addressbook.ValueObjects;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class NonEmptyStringFPTests
    {
        [Theory]
        [InlineData("a", true)]
        [InlineData("", false)]
        [InlineData((string) null, false)]
        public void NonEmptyStringFP_creation_with_smart_ctor_works(string input, bool isValid)
        {
            // Act
            var result = NonEmptyStringFP.Create(input);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeOfType<Option<NonEmptyStringFP>>();

            result.Match(
                () => isValid.Should().BeFalse(),
                x => x.Value.Should().Be(isValid ? input : null));
        }
    }
}