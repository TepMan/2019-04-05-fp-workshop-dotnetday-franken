using System;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LaYumba.Functional;

namespace ContactList.Tests
{
    public class LaYumbaTestAssertions<T>
        : ReferenceTypeAssertions<Option<T>, LaYumbaTestAssertions<T>> where T: struct
    {
        protected override string Identifier => "optionXX";

        public LaYumbaTestAssertions(Option<T> instance) => Subject = instance;

        // TODO Doesn't work yet..
        public AndConstraint<LaYumbaTestAssertions<T>> HaveFunc(Func<T, bool> f)
        {
            Execute.Assertion
                .Given(() => Subject)
                .ForCondition(optionOfT 
                    => optionOfT.Match(
                        None: () => false,
                        Some: x => f(x)
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
                        None: () => false,
                        Some: x => x.Equals(t)
                ))
                .FailWith("bla bla");

            return new AndConstraint<LaYumbaTestAssertions<T>>(this); 
        }
    }
}