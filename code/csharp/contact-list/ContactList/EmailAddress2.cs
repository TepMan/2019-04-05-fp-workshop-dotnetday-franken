using System;
using CSharpFunctionalExtensions;

namespace ContactList
{
    public class EmailAddress2
    {
        private EmailAddress2(string potentialEmailAddress)
        {
            if (!IsValid(potentialEmailAddress))
            {
                throw new ArgumentException();    
            }

            Value = potentialEmailAddress;
        }

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

        public string Value { get; }
        
        private bool IsValid(string potentialEmailAddress)
        {
            if (string.IsNullOrWhiteSpace(potentialEmailAddress)) return false;

            try { new System.Net.Mail.MailAddress(potentialEmailAddress); }
            catch (Exception) { return false; }
            
            return true;
        }

        // Syntactic sugar...
        public static implicit operator string(EmailAddress2 emailAddress)
        {
            return emailAddress.Value;
        }
    }
}
