using System;
using LaYumba.Functional;
// <-- !! Not built into C#; provides "Option" !!

namespace Addressbook.ValueObjects
{
    public static class EmailAddressSimpleCreator
    {
        public static Option<EmailAddressSimple> CreateFrom(string potentialEmail)
        {
            Option<EmailAddressSimple> result;

            try
            {
                result = F.Some(new EmailAddressSimple(potentialEmail));
            }
            catch (Exception)
            {
                result = F.None;
            }

            return result;
        }
    }
}