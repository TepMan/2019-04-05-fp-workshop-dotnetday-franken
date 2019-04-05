using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace AddressBook
{
    public class Contact
    {
        public string FirstName { get;  }
        public string LastName { get;  }
        public Option<DateTime> DateOfBirth { get; }
        public Option<string> TwitterHandler { get;  }

        public Contact(string firstName, string lastName, DateTime? dateOfBirth, string twitterHandler)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = NullableDateTimeToOption(dateOfBirth);
            TwitterHandler = StringToOption(twitterHandler);
        }

        private Option<DateTime> NullableDateTimeToOption(DateTime? date)
        {
            if (date == null)
            {
                return None;
            }

            return Some(date.Value);
        }
        private Option<string> StringToOption(string value)
        {
            if (value == null)
            {
                return None;
            }

            return Some(value);
        }

    }
}