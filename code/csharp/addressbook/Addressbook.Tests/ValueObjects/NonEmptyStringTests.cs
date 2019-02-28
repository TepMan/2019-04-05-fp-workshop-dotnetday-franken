using System;
using Addressbook.ValueObjects;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;

namespace Addressbook.Tests.ValueObjects
{
    public class NonEmptyStringTests
    {
        [Theory]
        [InlineData("a", true)]
        [InlineData("", false)]
        [InlineData((string) null, false)]
        public void NonEmptyString_creation_works(string input, bool isValid)
        {
            // Act
            var result = NonEmptyString.Create(input);

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeOfType<Option<NonEmptyString>>();

            result.Match(
                () => isValid.Should().BeFalse(),
                x => x.Value.Should().Be(isValid ? input : null));

            //if (isValid)
            //{
            //    result.HasValue.Should().BeTrue();
            //    result.Value.Value.Should().Be(input);
            //}
            //else
            //{
            //    result.HasNoValue.Should().BeTrue();
            //}
        }

        [Theory]
        [InlineData("a", true)]
        [InlineData("", false)]
        [InlineData((string) null, false)]
        public void NonEmptyString_creation_with_bang_works(string input, bool isValid)
        {
            if (isValid)
            {
                var result = NonEmptyString.CreateBang(input);

                // Assert
                result.Should()
                    .NotBeNull()
                    .And.BeOfType<NonEmptyString>();

                result.Value.Should().Be(input);
            }
            else
            {
                Action action = () => NonEmptyString.CreateBang(input);
                action.Should().Throw<ArgumentException>().WithMessage("String may not be empty or null!");
            }
        }
    }
}