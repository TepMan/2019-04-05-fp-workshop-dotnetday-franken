using System;
using LaYumba.Functional;

namespace AddressBook
{
    public static class DateFormatter
    {
        public static string Format(Option<DateTime> optDateTime)
        {
            return optDateTime.Match(
                () => "",
                (dt) => dt.ToShortDateString());
        }
    }
}