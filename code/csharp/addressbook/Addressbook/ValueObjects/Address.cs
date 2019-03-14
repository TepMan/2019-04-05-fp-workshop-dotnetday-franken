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