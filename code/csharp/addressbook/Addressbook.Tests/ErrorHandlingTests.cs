using Addressbook.ValueObjetcs;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace Addressbook.Tests
{
    public class ErrorHandlingTests
    {
        [Fact]
        public void Chain_of_maybes_collects_all_errors()
        {
        }

        [Fact]
        public void Chain_of_maybes_returns_after_first_error()
        {
            var maybeEmail1 = EmailAddress2.Create("homer.simpson@springfield.com");
            var maybeEmail2 = EmailAddress2.Create("invalid1");
            var maybeEmail3 = EmailAddress2.Create("invalid2");

            var result = maybeEmail1.ToResult("ups")
                .OnSuccess(() => maybeEmail2.ToResult("ups2"))
                .OnSuccess(() => maybeEmail3.ToResult("ups3"))
                .OnBoth(x => x.IsSuccess
                    ? "all ok"
                    : x.Error);

            result.Should().Be("ups2");
        }
    }
}