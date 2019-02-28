using System;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LaYumba.Functional;

namespace Addressbook.Tests
{
    public class LaYumbaTestAssertions<T>
        : ReferenceTypeAssertions<Option<T>, LaYumbaTestAssertions<T>> where T : struct
    {
        public LaYumbaTestAssertions(Option<T> instance)
        {
            Subject = instance;
        }

        protected override string Identifier => "optionXX";

        // TODO Doesn't work yet..
        public AndConstraint<LaYumbaTestAssertions<T>> HaveFunc(Func<T, bool> f)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(optionOfT
                    => optionOfT.Match(
                        () => false,
                        x => f(x)
                    ))
                .FailWith("bla bla");

            return new AndConstraint<LaYumbaTestAssertions<T>>(this);
        }

        public AndConstraint<LaYumbaTestAssertions<T>> BeT(T t)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(optionOfT
                    => optionOfT.Match(
                        () => false,
                        x => x.Equals(t)
                    ))
                .FailWith("bla bla");

            return new AndConstraint<LaYumbaTestAssertions<T>>(this);
        }
    }
}