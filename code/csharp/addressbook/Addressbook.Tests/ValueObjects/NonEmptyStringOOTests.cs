using System;
using Addressbook.ValueObjects;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;
using Addressbook.Tests.ValueObjects.TestExtensions;

namespace Addressbook.Tests.ValueObjects
{
    public class NonEmptyStringOOTests
    {
        [Theory]
        [InlineData("a", true)]
        [InlineData("", false)]
        [InlineData((string) null, false)]
        public void NonEmptyStringOO_creation_works(string input, bool isValid)
        {
            // Act
            var result = NonEmptyStringOO.Create(input);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeOfType<Option<NonEmptyStringOO>>();

            result.Match(
                () => isValid.Should().BeFalse(),
                x => x.Value.Should().Be(isValid ? input : null));
        }

        [Theory]
        [InlineData("a", true)]
        [InlineData("", false)]
        [InlineData((string) null, false)]
        public void NonEmptyStringOO_creation_with_bang_works(string input, bool isValid)
        {
            if (isValid)
            {
                var result = NonEmptyStringOO.CreateBang(input);

                // Assert
                result.Should()
                    .NotBeNull()
                    .And.BeOfType<NonEmptyStringOO>();

                result.Value.Should().Be(input);
            }
            else
            {
                Action action = () => NonEmptyStringOO.CreateBang(input);
                action.Should().Throw<ArgumentException>().WithMessage("String may not be empty or null!");
            }
        }

        // just testing if the extension method works
        [Theory]
        [InlineData("x", true)]
        [InlineData("", false)]
        public void NonEmptyStringOO_extension_handles_input_as_expected(string input, bool shouldPass)
        {
            var result = NonEmptyStringOO.Create(input);

            if (shouldPass)
            {
                result.Should().BeEqualToNonEmptyString(input);
                result.Should().NotBeEqualNonEmptyString(input + "x");
            }
            else
            {
                result.Should().BeNone();
            }
        }
    }
}