using System.Collections.Generic;
using System.Linq;

namespace Addressbook.PrimitiveContactManager
{
    public class FilterStrategy : IFilterStrategy
    {
        public IEnumerable<Contact2> Execute(IEnumerable<Contact2> contacts)
        {
            return contacts.Where(x => x.Iq > 60);
        }
    }
}