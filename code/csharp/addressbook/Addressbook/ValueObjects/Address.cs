using System.Collections.Generic;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    public class Address : ValueObject
    {
        public NonEmptyString Street { get; }
        public NonEmptyString City { get; }
        public Zipcode Zipcode { get; }

        private Address(NonEmptyString street, NonEmptyString city, Zipcode zipcode)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
        }

        public static Address Create(
            NonEmptyString street, 
            NonEmptyString city, 
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