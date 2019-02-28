using System.Collections.Generic;
using System.Linq;
using Addressbook.PrimitiveContactManager;
using FluentAssertions;
using Xunit;

namespace Addressbook.Tests.PrimitiveContactManager
{
    // TODO Adopt to original story "Addressbook"
    public class ContactManagerTests
    {
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