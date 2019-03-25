using System.Collections.Generic;

namespace Addressbook.ValueObjects
{
    public class AddressOO : ValueObject
    {
        public NonEmptyStringOO Street { get; }
        public NonEmptyStringOO City { get; }
        public ZipcodeOO Zipcode { get; }

        private AddressOO(NonEmptyStringOO street, NonEmptyStringOO city, ZipcodeOO zipcode)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
        }
       
        public static AddressOO Create(
            NonEmptyStringOO street, 
            NonEmptyStringOO city, 
            ZipcodeOO zipcode)
        {
            return new AddressOO(street, city, zipcode);
        }

        //public static Option<AddressOO> CreateOption(
        //    string street, 
        //    string city, 
        //    string zipcode)
        //{
        //    // TODO
        //    return None;
        //}

        //public static Either<string, AddressOO> CreateSimpleEither(
        //    string street, 
        //    string city, 
        //    string zipcode)
        //{
        //    // TODO
        //    return Left("x");
        //}

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