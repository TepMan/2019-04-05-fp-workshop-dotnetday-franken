using System.Collections.Generic;
using System.Linq;

namespace Addressbook.PrimitiveContactManager
{
    public class SimpleFormatStrategy : IFormatStrategy
    {
        public IEnumerable<string> Execute(IEnumerable<Contact2> contacts)
        {
            var result = new List<string>();
            foreach (var contact in contacts.Where(x => x != null)) result.Add(contact.Name);
            return result;
        }
    }
}