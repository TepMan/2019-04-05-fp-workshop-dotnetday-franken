using System;
using System.Collections.Generic;
using System.Net.Mail;
using LaYumba.Functional;

using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    // This class mimics a "record type" wrapped in a Maybe (also called Option).
    //
    // An instance can only be created using the static "Create" method. 
    //
    // The static "Create" method returns a "Maybe<EmailAddress>"
    //
    // The "Create" method will always return a valid answer of type Maybe<EmailAddress> (and not throw an exception).
    // Consumers of this class must handle the result.
    //
    // Other alternative: EmailAddressSimple -> throws Exception
    //
    public class EmailAddress : ValueObject
    {
        private EmailAddress(string potentialEmailAddress)
        {
            if (!IsValid(potentialEmailAddress))
                throw new ArgumentException($"Invalid email address: {potentialEmailAddress}");

            Value = potentialEmailAddress;
        }

        public string Value { get; }

        public static Option<EmailAddress> Create(string potentialEmailAddress)
        {
            Option<EmailAddress> result;

            try
            {
                result = Some(new EmailAddress(potentialEmailAddress));
            }
            catch (Exception)
            {
                result = None;
            }

            return result;
        }

        public static object CreateBang(string input)
        {
            return new EmailAddress(input);
        }

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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        // Syntactic sugar...
        public static implicit operator string(EmailAddress emailAddress)
        {
            return emailAddress.Value;
        }
    }
}