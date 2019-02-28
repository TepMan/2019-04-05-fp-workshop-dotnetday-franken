using System;
using LaYumba.Functional; // <-- !! Not built into C#; provides "Option" !!

using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    public static class EmailAddress1Creator
    {
        public static Option<EmailAddress1> CreateFrom(string potentialEmail)
        {
            Option<EmailAddress1> result;

            try
            {
                result = Some(new EmailAddress1(potentialEmail));
            }
            catch (Exception)
            {
                result = None;
            }

            return result;
        }
    }
}