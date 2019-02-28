using System.Collections.Generic;

namespace Addressbook.PrimitiveContactManager
{
    public interface IFilterStrategy
    {
        IEnumerable<Contact2> Execute(IEnumerable<Contact2> contacts);
    }
}