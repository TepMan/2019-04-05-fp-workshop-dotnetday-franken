using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    public class ZipcodeFP
    {
        public NonEmptyStringFP Value { get; }

        private ZipcodeFP(NonEmptyStringFP zipcode) => Value = zipcode;

        // smart ctor
        public static Func<Option<NonEmptyStringFP>, Option<ZipcodeFP>> Create
            = optNonEmpty => optNonEmpty.Match(
                () => None,
                nonEmptyStringFP 
                    => nonEmptyStringFP.Value.IsValidZipcode()
                        ? Some(new ZipcodeFP(nonEmptyStringFP))
                        : None);

        public override string ToString() => Value.Value;
    }
}