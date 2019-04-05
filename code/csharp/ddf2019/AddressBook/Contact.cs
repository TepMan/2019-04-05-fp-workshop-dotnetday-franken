using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace AddressBook
{
    public class Contact
    {
        public NonEmptyString FirstName { get;  }
        public NonEmptyString LastName { get;  }
        public DateTime DateOfBirth { get; }
        public string TwitterHandler { get;  }

        private Contact(
            NonEmptyString firstName, 
            NonEmptyString lastName, 
            DateTime dateOfBirth, 
            string twitterHandler)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TwitterHandler = twitterHandler;
        }

        public static Either<string, Contact> Create(
            string firstName,
            string lastName,
            DateTime? dateOfBirth,
            string twitterHandler)
        {
            var eitherFn = NonEmptyString.Create(firstName);
            var eitherLn = NonEmptyString.Create(lastName);

            var eitherDob = NullableDateTimeTovalidation(dateOfBirth);

            var eitherTwitter = StringToValidation(twitterHandler);

            return Left("ups");
        }

        private static Func<NonEmptyString, NonEmptyString, DateTime, string, Contact> Create2 
            = (fn, ln, dob, twitter) => new Contact(fn, ln, dob, twitter);

        public static Func<string, string, DateTime?, string, Either<string, Contact>> Validate(string firstName,
            string lastName,
            DateTime? dateOfBirth,
            string twitterHandler)
        {
            var create2 = Create2;
            
            Validation<Func<NonEmptyString, NonEmptyString, DateTime, string, Contact>> validation = Valid(create2);

            Validation<NonEmptyString> validation1 = ValidName("a");

            //var x = validation.Apply(ValidName(firstName));

            //Valid(Create)
            return null;
        }

        private static Func<string, Validation<NonEmptyString>> ValidName 
            = s => NonEmptyString.Create(s);

        private static Validation<DateTime> NullableDateTimeTovalidation(DateTime? date)
        {
            if (date == null)
            {
                return Error("ups dt");
            }

            return Valid(date.Value);
        }
        private static Validation<string> StringToValidation(string value)
        {
            if (value == null)
            {
                return Error("ups");
            }

            return Valid(value);
        }

    }
}