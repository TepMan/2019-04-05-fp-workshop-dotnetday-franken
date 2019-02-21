using System;
using CSharpFunctionalExtensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace ContactList.Tests
{
    public static class EmailAddressTestExtensions
    {
        public static bool IsOkAndHasValue<T>(this Maybe<T> maybe, T expected) 
        {
            if (maybe.HasNoValue)
            {
                return false;
            }

            return maybe.Value.Equals(expected);
        }

        public static EmailAddressAssertions Should(this Maybe<EmailAddress2> instance)
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
        : 
        ReferenceTypeAssertions<Maybe<EmailAddress2>, EmailAddressAssertions>
    {
        public EmailAddressAssertions(Maybe<EmailAddress2> instance)
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
                .FailWith("You can't assert another email if you don't pass a proper name")
                .Then
                .Given(() => Subject.Value)
                .ForCondition(email => email.Value == otherEmailString)
                .FailWith("Expected {context:email} to be {0}{reason}, but found {1}", 
                    otherEmailString, Subject.Value.Value);

            return new AndConstraint<EmailAddressAssertions>(this); 
        }
    }
}