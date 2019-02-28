using System;
using System.Net.Mail;

namespace Addressbook.ValueObjects
{
    // This implementation throws an exception when the given email is invalid
    // 
    // This pattern prevents the anti-pattern "primitive obsession".
    //
    // This is a minimalist "value object" from domain driven design (equality features are missing)
    //
    // "value objects" are IMMUTABLE!
    //
    // HINT: Other languages have this data type built in (i.e. record types in F#)
    public class EmailAddress1
    {
        public EmailAddress1(string potentialEmailAddress)
        {
            if (!IsValid(potentialEmailAddress)) throw new ArgumentException();

            Value = potentialEmailAddress;
        }

        public string Value { get; }

        private bool IsValid(string potentialEmailAddress)
        {
            if (string.IsNullOrWhiteSpace(potentialEmailAddress)) return false;

            try
            {
                new MailAddress(potentialEmailAddress);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        // Syntactic sugar...
        public static implicit operator string(EmailAddress1 emailAddress)
        {
            return emailAddress.Value;
        }
    }
}