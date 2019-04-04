using System.Collections.Generic;
using System.Linq;
using Addressbook.PrimitiveContactManager;
using FluentAssertions;
using Xunit;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Addressbook.Tests.PrimitiveContactManager
{

    public class Data
    {
        public string Name;
    }
    public class Do
    {
        public Data CreateData() => null;

        public string CreateAndUseData()
        {
            var data = CreateData();
            // kein null-Check -> ist dem Compiler egal
            return data.Name;
        }
    }


    // TODO Adopt to original story "Addressbook"
    public class ContactManagerTests
    {
        // Enthält die Signatur die ganze Wahrheit?
        public string Stringify<T>(T data)
        {
            return null;
        }

        // Sind Magic Values eine gute Idee?
        public int Intify(string s)
        {
            int result = -1;
            int.TryParse(s, out result);
            return result;
        }

        public Option<int> IntifyOption(string s)
        {
            int result = -1;
            bool success = int.TryParse(s, out result);
            return success ? Some(result) : None;
        }

        public string Stringify<T>(Option<T> data)
        {
            return data.Match(
                None: () => "",
                Some: (existingData) => existingData.ToString()
            );
        }


        [Fact]
        public void ContactManager_works()
        {
            List<Contact2> contacts = new List<Contact2>
            {
                new Contact2 {Name = "Homer", Iq = 50},
                new Contact2 {Name = "Lisa", Iq = 120},
                new Contact2 {Name = "Bart", Iq = 90},
            };

            var contactManager = new ContactManager();
            contactManager.Add(contacts);

            var filterStrategy = new FilterStrategy();
            contactManager.Filter(filterStrategy);

            var formattedStrings = contactManager.Format(new SimpleFormatStrategy());
            IPrintStrategy printStrategy = new PrintStrategy();

            var result = contactManager.Print(formattedStrings, printStrategy);

            result.Should().Be("Lisa,Bart");
        }

        [Fact]
        public void Passing_all_functions_into_Manager_works()
        {
            var contacts = new List<Contact2>
            {
                new Contact2 {Name = "Homer", Iq = 50},
                new Contact2 {Name = "Lisa", Iq = 120},
                new Contact2 {Name = "Bart", Iq = 90},
            };

            var contactManager = new ContactManager();

            //var result = contactManager.FilterMapReduce(contacts,
            //    new FilterStrategy().Execute,
            //    new SimpleFormatStrategy().Execute,
            //    new PrintStrategy().Execute);

            //var result = contactManager.FilterMapReduce(contacts,
            //    x => x.Where(y => y.Iq > 60),
            //    x => x.Select(y => y.Name),
            //    x => x.Aggregate((a, b) => $"{a},{b}"));

            var result = contacts
                .Where(y => y.Iq > 60)
                .Select(y => y.Name)
                .Aggregate((a, b) => $"{a},{b}");

            result.Should().Be("Lisa,Bart");
        }
    }
}