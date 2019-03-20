using System;
using System.Collections.Generic;
using LaYumba.Functional;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Addressbook.ValueObjects;
using static LaYumba.Functional.F;

namespace Addressbook.Tests.ValueObjects.TestExtensions
{
    public static class NonEmptyStringTestExtensions 
    {
        public static NonEmptyStringOOAssertions Should(this Option<NonEmptyStringOO> instance)
        {
            return new NonEmptyStringOOAssertions(instance);
        }

        public static NonEmptyStringFPAssertions Should(this Option<NonEmptyStringFP> instance)
        {
            return new NonEmptyStringFPAssertions(instance);
        }
    }

    public class NonEmptyStringOOAssertions
        : ReferenceTypeAssertions<Option<NonEmptyStringOO>, NonEmptyStringOOAssertions>
    {
        public NonEmptyStringOOAssertions(Option<NonEmptyStringOO> instance)
        {
            Subject = instance;
        }

        protected override string Identifier => "nonEmptyString";

        public AndConstraint<NonEmptyStringOOAssertions> BeEqualToNonEmptyString(
            string otherString,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!string.IsNullOrWhiteSpace(otherString))
                .FailWith("You can't compare NonEmptyString if you provide an empty NonEmptyString.")
                .Then
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => false,
                    x => x.Value == otherString))
                .FailWith("Expected {context:nonEmptyString} to be {0}{reason}, but found {1}",
                    otherString, Subject);

            return new AndConstraint<NonEmptyStringOOAssertions>(this);
        }

        public AndConstraint<NonEmptyStringOOAssertions> NotBeEqualNonEmptyString(
            string otherString,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => false,
                    x => x.Value != otherString))
                .FailWith("Expected {context:nonEmptyString} not to be {0}{reason}, but found {1}",
                    otherString, Subject);

            return new AndConstraint<NonEmptyStringOOAssertions>(this);
        }

        public AndConstraint<NonEmptyStringOOAssertions> BeNone(
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => true,
                    x => x.Value == null))
                .FailWith("Expected {context:nonEmptyString} to be None {reason}, but found {1}",
                    Subject);

            return new AndConstraint<NonEmptyStringOOAssertions>(this);
        }
    }

    public class NonEmptyStringFPAssertions
        : ReferenceTypeAssertions<Option<NonEmptyStringFP>, NonEmptyStringFPAssertions>
    {
        public NonEmptyStringFPAssertions(Option<NonEmptyStringFP> instance)
        {
            Subject = instance;
        }

        protected override string Identifier => "nonEmptyString";

        public AndConstraint<NonEmptyStringFPAssertions> BeEqualToNonEmptyString(
            string otherString,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!string.IsNullOrWhiteSpace(otherString))
                .FailWith("You can't compare NonEmptyString if you provide an empty NonEmptyString.")
                .Then
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => false,
                    x => x.Value == otherString))
                .FailWith("Expected {context:nonEmptyString} to be {0}{reason}, but found {1}",
                    otherString, Subject);

            return new AndConstraint<NonEmptyStringFPAssertions>(this);
        }

        public AndConstraint<NonEmptyStringFPAssertions> NotBeEqualNonEmptyString(
            string otherString,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => false,
                    x => x.Value != otherString))
                .FailWith("Expected {context:nonEmptyString} not to be {0}{reason}, but found {1}",
                    otherString, Subject);

            return new AndConstraint<NonEmptyStringFPAssertions>(this);
        }

        public AndConstraint<NonEmptyStringFPAssertions> BeNone(
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(opt => opt.Match(
                    () => true,
                    x => x.Value == null))
                .FailWith("Expected {context:nonEmptyString} to be None {reason}, but found {1}",
                    Subject);

            return new AndConstraint<NonEmptyStringFPAssertions>(this);
        }
    }
}