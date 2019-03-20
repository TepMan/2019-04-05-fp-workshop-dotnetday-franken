using System;
using System.Collections.Generic;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    public class Address : ValueObject
    {
        public NonEmptyStringOO Street { get; }
        public NonEmptyStringOO City { get; }
        public Zipcode Zipcode { get; }

        private Address(NonEmptyStringOO street, NonEmptyStringOO city, Zipcode zipcode)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
        }

        // smart ctor
        public static Func<NonEmptyStringOO, NonEmptyStringOO, Zipcode, Address> Create 
            = (street, city, zipcode) => new Address(street, city, zipcode);

        public static Address CreateClassic(
            NonEmptyStringOO street, 
            NonEmptyStringOO city, 
            Zipcode zipcode)
        {
            return new Address(street, city, zipcode);
        }

        public static Option<Address> CreateOption(
            string street, 
            string city, 
            string zipcode)
        {
            // TODO
            return None;
        }

        public static Either<string, Address> CreateSimpleEither(
            string street, 
            string city, 
            string zipcode)
        {
            // TODO
            return Left("x");
        }

        // TODO Use Error types -> Railway Oriented Programming
//        public static Either<Error, Address> CreateSimpleEither(
//            string street, 
//            string city, 
//            string zipcode)
//        {
//            // TODO
//            return Left("x");
//        }


        
        
        
        // Currently the same as `Create`
//        public static Address CreateBang(
//            NonEmptyString street, 
//            NonEmptyString city, 
//            Zipcode zipcode)
//        {
//            return new Address(street, city, zipcode);
//        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return Zipcode;
        }
    }
}