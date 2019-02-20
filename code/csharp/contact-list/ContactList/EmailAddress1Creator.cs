using System;
using CSharpFunctionalExtensions; // <-- !! Not built into C#; provides "Maybe" !!

namespace ContactList
{
    public static class EmailAddress1Creator
    {
        public static Maybe<EmailAddress1> CreateFrom(string potentialEmail)
        {
            Maybe<EmailAddress1> result;

            try
            {
                result = Maybe<EmailAddress1>.From(new EmailAddress1(potentialEmail));
            }
            catch (Exception)
            {
                result = Maybe<EmailAddress1>.None;
            }

            return result;
        }
    }
}