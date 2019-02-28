using System.Collections.Generic;

namespace Addressbook.Tests.PrimitiveContactManager
{
    public interface IFormatStrategy
    {
        IEnumerable<string> Execute(IEnumerable<Contact2> contacts);
    }
}