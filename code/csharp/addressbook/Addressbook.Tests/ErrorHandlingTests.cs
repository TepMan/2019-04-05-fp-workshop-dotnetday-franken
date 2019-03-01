using System.Linq;
using Addressbook.ValueObjects;
using FluentAssertions;
using LaYumba.Functional;
using Xunit;
using static LaYumba.Functional.F;

namespace Addressbook.Tests
{
    /// <summary>
    ///     TODO Demo for Applicatives
    /// </summary>
    public class ErrorHandlingTests
    {
        /// <summary>
        ///     ...also referred to as "Railway Oriented Programming"...
        /// </summary>
        [Fact]
        public void Chain_of_validations_returns_after_first_error()
        {
            var optMail1 = EmailAddress2.Create("homer.simpson@springfield.com");

            var result = optMail1
                .ToValidation("ups1")
                .Bind(mail => mail.Value.StartsWith("x")
                    ? Valid(mail)
                    : Invalid("does not start with x"))
                .Bind(mail => mail.Value.Contains("homer")
                    ? Valid(mail)
                    : Invalid("does not contain homer"))
                .Match(
                e => e.Aggregate((a,b) => $"{a},{b}"),
                x => x.Value
                );

            result.Message.Should().Be("does not start with x");
        }

        //[Fact]
        //public void Chain_of_validations_collects_all_errors()
        //{
        //    var optMail1 = EmailAddress2.Create("homer.simpson@springfield.com");

        //    var result = optMail1
        //        .ToValidation("ups1")
        //        .Apply(mail => mail.Value.Contains("homer")
        //            ? Valid(mail)
        //            : Invalid("does not contain homer"));
        //    //.Match(
        //    //    e => e.Aggregate((a,b) => $"{a},{b}"),
        //    //    x => x.Value
        //    //);

        //    //result.Message.Should().Be("does not start with x");
        //}
    }

    public static class ErrorHandlingExtensions
    {
        public static Validation<T> ToValidation<T>
            (this Option<T> opt, string msg) 
                =>
                    opt.Match(
                        () => Invalid(msg),
                        Valid);
    }
}