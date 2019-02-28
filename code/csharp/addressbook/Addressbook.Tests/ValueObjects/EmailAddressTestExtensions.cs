using System;
using DemoCsharp.Addressbook.ValueObjects;
using CSharpFunctionalExtensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace DemoCsharp.Addressbook.Tests.ValueObjects
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
        : ReferenceTypeAssertions<Maybe<EmailAddress2>, EmailAddressAssertions>
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
                .FailWith("You can't compare emails if you provide an empty email string.")
                .Then
                .Given(() => Subject.Value)
                .ForCondition(email => email.Value == otherEmailString)
                .FailWith("Expected {context:email} to be {0}{reason}, but found {1}", 
                    otherEmailString, Subject.Value.Value);

            return new AndConstraint<EmailAddressAssertions>(this); 
        }

        public AndConstraint<EmailAddressAssertions> NotBeEqualToEmailString(
            string otherEmailString, 
            string because = "", 
            params object[] becauseArgs)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(maybeMail => maybeMail.HasNoValue || maybeMail.Value != otherEmailString)
                .FailWith("Expected {context:email} not to be {0}{reason}, but found {1}", 
                    otherEmailString, Subject.Value.Value);

            return new AndConstraint<EmailAddressAssertions>(this); 
        }
    }
}