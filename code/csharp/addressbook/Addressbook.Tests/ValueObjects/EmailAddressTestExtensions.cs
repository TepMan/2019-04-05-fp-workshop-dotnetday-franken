using Addressbook.ValueObjects;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LaYumba.Functional;

namespace Addressbook.Tests.ValueObjects
{
    public static class EmailAddressTestExtensions
    {
        public static EmailAddressAssertions Should(this Option<EmailAddress> instance)
        {
            return new EmailAddressAssertions(instance);
        }
    }

    // Deriving from `ReferenceTypeAssertions` gives us the following methods for free:
    //
    // - `BeNull`
    // - `BeSameAs`
    // - `Match`
    public class EmailAddressAssertions
        : ReferenceTypeAssertions<Option<EmailAddress>, EmailAddressAssertions>
    {
        public EmailAddressAssertions(Option<EmailAddress> instance)
        {
            Subject = instance;
        }

        protected override string Identifier => "email";

        public AndConstraint<EmailAddressAssertions> BeEqualToEmailString(
            string otherEmailString,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!string.IsNullOrWhiteSpace(otherEmailString))
                .FailWith("You can't compare emails if you provide an empty email string.")
                .Then
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => false,
                    x => x == otherEmailString))
                .FailWith("Expected {context:email} to be {0}{reason}, but found {1}",
                    otherEmailString, Subject);

            return new AndConstraint<EmailAddressAssertions>(this);
        }

        public AndConstraint<EmailAddressAssertions> NotBeEqualToEmailString(
            string otherEmailString,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => false,
                    x => x != otherEmailString))
                .FailWith("Expected {context:email} not to be {0}{reason}, but found {1}",
                    otherEmailString, Subject);

            return new AndConstraint<EmailAddressAssertions>(this);
        }
    }
}