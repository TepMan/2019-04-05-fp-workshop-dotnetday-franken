using System;
using System.Collections.Generic;
using System.Net.Mail;
using CSharpFunctionalExtensions;

namespace DemoCsharp.Addressbook.ValueObjects
{
    // This class mimics a "record type" wrapped in a Maybe (also called Option).
    //
    // An instance can only be created using the static "Create" method. 
    //
    // The static "Create" method returns a "Maybe<EmailAddress2>"
    //
    // The "Create" method will always return a valid answer of type Maybe<EmailAddress2> (and not throw an exception).
    // Consumers of this class must handle the result.
    //
    // Other alternative: EmailAddress1 -> throws Exception
    //
    public class EmailAddress2 : ValueObject
    {
        private EmailAddress2(string potentialEmailAddress)
        {
            if (!IsValid(potentialEmailAddress))
                throw new ArgumentException($"Invalid email address: {potentialEmailAddress}");

            Value = potentialEmailAddress;
        }

        public string Value { get; }

        public static Maybe<EmailAddress2> Create(string potentialEmailAddress)
        {
            Maybe<EmailAddress2> result;

            try
            {
                result = Maybe<EmailAddress2>.From(new EmailAddress2(potentialEmailAddress));
            }
            catch (Exception)
            {
                result = Maybe<EmailAddress2>.None;
            }

            return result;
        }

        public static object CreateBang(string input)
        {
            return new EmailAddress2(input);
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
        public static implicit operator string(EmailAddress2 emailAddress)
        {
            return emailAddress.Value;
        }
    }
}