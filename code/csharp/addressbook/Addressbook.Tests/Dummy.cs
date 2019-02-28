using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Addressbook.Tests
{
    public class Dummy
    {
        [Fact]
        public void Foo()
        {
            IEnumerable<Contact2> contacts = new List<Contact2>();
            
            var god = new GodClass();
            god.Add(contacts);
            // god.Filter().Format().Print()

            var filterStrategy = new FilterStrategy();
            god.Filter(filterStrategy);
            // god.Format()
        }


        public class GodClass
        {
            public IEnumerable<Contact2> Contacts { get; private set; }

            public void Add(IEnumerable<Contact2> contacts) 
            {
                this.Contacts = contacts;
            }

            public void Filter(IFilterStrategy filterStrategy)
            {
                Contacts = filterStrategy.Execute(Contacts);
            }
        }
    }

    public class FilterStrategy : IFilterStrategy
    {
        public FilterStrategy()
        {
        }

        public IEnumerable<Contact2> Execute(IEnumerable<Contact2> contacts)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IFilterStrategy
    {
        IEnumerable<Contact2> Execute(IEnumerable<Contact2> contacts);
    }
    
    public interface IFormatStrategy
    {
        IEnumerable<string> Execute(IEnumerable<Contact2> contacts);
    }

    public class SimpleFormatStrategy : IFormatStrategy
    {
        public IEnumerable<string> Execute(IEnumerable<Contact2> contacts)
        {
            var result = new List<string>();
            foreach (var contact in contacts.Where(x => x != null))
            {
                result.Add(contact.Name);
            }
            return result;
        }
    }

    public class Contact2 {
        public string Name { get; set; }
    }
}