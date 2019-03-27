using System;
using System.Collections.Generic;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    public class AddressFP : ValueObject
    {
        public NonEmptyStringFP Street { get; }
        public NonEmptyStringFP City { get; }
        public ZipcodeFP Zipcode { get; }

        private AddressFP(NonEmptyStringFP street, NonEmptyStringFP city, ZipcodeFP zipcode)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
        }

        // smart ctor
        public static readonly Func<NonEmptyStringFP, NonEmptyStringFP, ZipcodeFP, AddressFP> Create
            = (street, city, zipcode) => new AddressFP(street, city, zipcode);

        // Applicative validation
        public static Validation<AddressFP> CreateValidAddress(string street, string city, string zipcode)
            => Valid(Create)
                .Apply(ValidStreet(street))
                .Apply(ValidCity(city))
                .Apply(ValidZipCode(zipcode));

        private static readonly Func<string, Validation<NonEmptyStringFP>> ValidStreet
            = s => NonEmptyStringFP.Create(s).Match(
                () => Error($"Invalid street: '{s}'"),
                validStreet => Valid(validStreet));

        private static readonly Func<string, Validation<NonEmptyStringFP>> ValidCity
            = c => NonEmptyStringFP.Create(c).Match(
                () => Error($"Invalid city: '{c}'"),
                validCity => Valid(validCity));

        private static readonly Func<string, Validation<ZipcodeFP>> ValidZipCode
            = z => ZipcodeFP.Create(NonEmptyStringFP.Create(z)).Match(
                () => Error($"Invalid zipcode: '{z}'"),
                validZipCode => Valid(validZipCode));

        public override string ToString() 
            => $"Street: {Street}; City: {City}; Zipcode: {Zipcode}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return Zipcode;
        }
    }
}