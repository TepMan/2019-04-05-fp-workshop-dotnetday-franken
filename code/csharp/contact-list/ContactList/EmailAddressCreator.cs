using System;
using CSharpFunctionalExtensions; // <-- !! Not built into C#; provides "Maybe" !!

namespace ContactList
{
    public static class EmailAddressCreator
    {
        public static Maybe<EmailAddress> CreateFrom(string potentialEmail)
        {
            Maybe<EmailAddress> result;

            try
            {
                result = Maybe<EmailAddress>.From(new EmailAddress(potentialEmail));
            }
            catch (Exception)
            {
                result = Maybe<EmailAddress>.None;
            }

            return result;
        }
    }
}