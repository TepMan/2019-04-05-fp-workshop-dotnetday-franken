using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace AddressBook
{
    public static class Persistenz
    {
        public static Either<string, string> Save(this string content)
        {
            if (content.StartsWith("x"))
                return Right(content);

            return Left("Saving to database failed.");
        }

        public static Either<string, string> SendMessage(this string content)
        {
            Console.WriteLine("Irgendwas");
            return Right(content);
        }

        public static Either<string,string> SaveAndSendMessage(this string content)
        {
            Either<string, string> result1 = Save(content);
            return result1.Bind(SendMessage);
        }

    }
}