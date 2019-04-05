using System;
using System.Security.Cryptography;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using String = LaYumba.Functional.String;

namespace AddressBook
{

    public static class MyValidate
    {
        public static Func<string, Validation<string>> isNotEmpty 
            = s => string.IsNullOrEmpty(s) ? Error("must not be empty") : Valid(s);

        public static Func<string, Validation<string>> startsWithX 
            = s => s.StartsWith("x") ? Valid(s) : Error("must start with x");

        public static Func<string, Validation<string>> notTooLong 
            = s => s.Length <= 5 ? Valid(s) : Error("must not be longer than 5");       
    }

    public class Workflow
    {
        public static Func<string, string, string> Create = (s1, s2) => string.Empty;

        public static Func<string, Validation<string>> validateFirstName 
            = s =>
            {
                return MyValidate.isNotEmpty(s)
                    .Bind(MyValidate.startsWithX)
                    .Bind(MyValidate.notTooLong);
            };
        
        public static Func<string, Validation<string>> validateLastName
            = s => s.StartsWith("x") ? Valid(s) : Error("invalid last name");

        public static Validation<string> Validate(string firstName, string lastName)
        {
            Validation<string> result = Valid(Create)
                .Apply(validateFirstName(firstName))
                .Apply(validateLastName(lastName));

            return result;
        }
    }
}