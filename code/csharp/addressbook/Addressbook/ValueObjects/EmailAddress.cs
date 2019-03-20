using System;
using System.Collections.Generic;
using System.Net.Mail;
using LaYumba.Functional;

using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    // This class mimics a "record type" wrapped in an Option (also called Maybe).
    //
    // An instance can only be created using the static "Create" method. 
    //
    // The static "Create" method returns a "Option<EmailAddress>"
    //
    // The "Create" method will always return a valid answer of type Option<EmailAddress> (and not throw an exception).
    // Consumers of this class must handle the result.
    //
    // Other alternative: EmailAddressSimple -> throws Exception
    //
    public class EmailAddress : ValueObject
    {
        private EmailAddress(string validatedEmailAddress)
        {
            Value = validatedEmailAddress;
        }

        public string Value { get; }

        // smart ctor
        public static Func<string, Option<EmailAddress>> CreateInternalValidation
            = s => IsValid(s)
                ? Some(new EmailAddress(s))
                : None;

        // smart ctor
        // public static Func<string, bool, Option<EmailAddress>> Create
        //     => f => 

        
        // This validation method can be injected
        public static bool IsValid(string potentialEmailAddress)
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(EmailAddress emailAddress)
        {
            return emailAddress.Value;
        }
    }
}