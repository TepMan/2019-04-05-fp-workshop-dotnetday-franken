using System;

namespace ContactList
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
        public EmailAddress1(string s)
        {
            if (!IsValid(s))
            {
                throw new ArgumentException();    
            }

            Value = s;
        }

        public string Value { get; }
        
        private bool IsValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;

            try { new System.Net.Mail.MailAddress(s); }
            catch (Exception) { return false; }
            
            return true;
        }

        // Syntactic sugar...
        public static implicit operator string(EmailAddress1 valueObject)
        {
            return valueObject.Value;
        }
    }
}
