using System;
using System.Collections.Generic;
using LaYumba.Functional;

namespace Addressbook.ValueObjects
{
    // Object-Oriented solution
    // - Value Object
    // - private ctor
    // - validation in ctor
    public class ZipcodeOO : ValueObject
    {
        private ZipcodeOO(NonEmptyStringOO potentialZipcode)
        {
            if (!IsValid(potentialZipcode))
            {
                throw new ArgumentException($"Invalid zip code! {potentialZipcode}");
            }
            
            Value = potentialZipcode.Value;
        }

        public string Value { get; }

        // Just another rule..
        private static bool IsValid(NonEmptyStringOO potentialZipcode) => 
            potentialZipcode.Value.Length >= 3;

        public static Option<ZipcodeOO> Create(NonEmptyStringOO potentialZipcode)
        {
            Option<ZipcodeOO> result;

            try
            {
                result = F.Some(new ZipcodeOO(potentialZipcode));
            }
            catch (Exception)
            {
                result = F.None;
            }

            return result;
        }

        public static Option<ZipcodeOO> Create(string potentialZipcode)
        {
            var option = NonEmptyStringOO.Create(potentialZipcode);
            return option.Match(
                () => F.None,
                Create);
        }

        public static ZipcodeOO CreateBang(string potentialZipcode)
        {
            return new ZipcodeOO(NonEmptyStringOO.CreateBang(potentialZipcode));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    /// <summary>
    ///     Why inheritance sucks!
    ///     Let's try to derive from NonEmptyString:
    ///     - same pattern: private ctor, static Create method.
    ///     No matter what we do, we can't change the `base.Value` object!
    ///     If we would attempt this (f.ex. by making NonEmptyString.Value `internal sealed`) we would lose
    ///     - Immutability!
    ///     - and we would be violating Liskov!
    ///     Don't do this!
    ///     Or is there another solution which works that I missed?
    /// </summary>
//    public class Zipcode2 : NonEmptyString
//    {
//        private Zipcode2(string potentialZipcode)
//        {
//            if (!IsValid(potentialZipcode))
//            {
//                throw new ArgumentException($"Invalid zip code! {potentialZipcode}");
//            }
//            
//            // We can't set `Value`!!    
////            Value = potentialZipcode;
//        }
//
//        private static bool IsValid(string potentialZipcode)
//        {
//            return potentialZipcode.Length < 10;
//        }
//
//        public static Option<Zipcode2> Create(string potentialZipcode)
//        {
//            var option = NonEmptyString.Create(potentialZipcode);
//            option.Match(
//                () => None,
//                x => Some(new Zipcode2(x.Value)));
//        }

//        public static Zipcode2 CreateBang(NonEmptyString potentialZipcode)
//        {
//            return new Zipcode2(potentialZipcode);
//        }
//    }

}