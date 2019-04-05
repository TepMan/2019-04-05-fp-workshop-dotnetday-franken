using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace AddressBook
{
    public static class Persistenz
    {
        public static Option<string> Save(this string content)
        {
            if (content.StartsWith("x"))
                return Some(content);

            return None;
        }

        public static Option<string> SendMessage(this string content)
        {
            Console.WriteLine("Irgendwas");
            return Some(content);
        }

        public static Option<string> SaveAndSendMessage(this string content)
        {
            Option<string> result1 = Save(content);
            return result1.Bind(SendMessage);
        }

    }
}