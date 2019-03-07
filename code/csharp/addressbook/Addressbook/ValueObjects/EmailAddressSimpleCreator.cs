using System;
using LaYumba.Functional; // <-- !! Not built into C#; provides "Option" !!

using static LaYumba.Functional.F;

namespace Addressbook.ValueObjects
{
    public static class EmailAddressSimpleCreator
    {
        public static Option<EmailAddressSimple> CreateFrom(string potentialEmail)
        {
            Option<EmailAddressSimple> result;

            try
            {
                result = Some(new EmailAddressSimple(potentialEmail));
            }
            catch (Exception)
            {
                result = None;
            }

            return result;
        }
    }
}