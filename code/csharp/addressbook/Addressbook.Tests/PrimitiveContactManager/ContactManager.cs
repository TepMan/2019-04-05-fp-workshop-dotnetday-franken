using System;
using System.Collections.Generic;

namespace Addressbook.Tests.PrimitiveContactManager
{
    public class ContactManager
    {
        public IEnumerable<Contact2> Contacts { get; private set; }

        public void Add(IEnumerable<Contact2> contacts)
        {
            Contacts = contacts;
        }

        public void Filter(IFilterStrategy filterStrategy)
        {
            Contacts = filterStrategy.Execute(Contacts);
        }

        public IEnumerable<string> Format
            (IFormatStrategy formatStrategy)
        {
            return formatStrategy.Execute(Contacts);
        }

        public string Print(IEnumerable<string> formattedStrings, IPrintStrategy printStrategy)
        {
            return printStrategy.Execute(formattedStrings);
        }

        public string FilterMapReduce(
            IEnumerable<Contact2> contacts,
            Func<IEnumerable<Contact2>, IEnumerable<Contact2>> filter,
            Func<IEnumerable<Contact2>, IEnumerable<string>> format,
            Func<IEnumerable<string>, string> print)
        {
            var filtered = filter(contacts);
            var formatted = format(filtered);
            return print(formatted);
        }
    }
}