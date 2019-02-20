using System;

namespace ContactList
{
    // This implementation throws an exception when the given email is invalid
    public class EmailAddress
    {
        public EmailAddress(string s)
        {
            if (!IsValid(s))
            {
                throw new ArgumentException();    
            }

            Value = s;
        }

        private bool IsValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;

            try { new System.Net.Mail.MailAddress(s); }
            catch (Exception) { return false; }
            
            return true;
        }

        public string Value { get; }

        public static implicit operator string(EmailAddress valueObject)
        {
            return valueObject.Value;
        }
    }
}
