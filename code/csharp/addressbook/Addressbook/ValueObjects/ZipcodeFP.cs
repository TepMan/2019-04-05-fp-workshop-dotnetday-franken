using System;
using LaYumba.Functional;

namespace Addressbook.ValueObjects
{
    public class ZipcodeFP
    {
        public NonEmptyStringFP Value { get; }

        private ZipcodeFP(NonEmptyStringFP zipcode) => Value = zipcode;

        // smart ctor
        public static readonly Func<Option<NonEmptyStringFP>, Option<ZipcodeFP>> Create
            = optNonEmpty => optNonEmpty.Match(
                () => F.None,
                nonEmptyStringFP 
                    => nonEmptyStringFP.Value.IsValidZipcode()
                        ? F.Some(new ZipcodeFP(nonEmptyStringFP))
                        : F.None);

        public override string ToString() => Value.Value;
    }
}