using System.Collections.Generic;

namespace Addressbook.Tests.PrimitiveContactManager
{
    public interface IFilterStrategy
    {
        IEnumerable<Contact2> Execute(IEnumerable<Contact2> contacts);
    }
}