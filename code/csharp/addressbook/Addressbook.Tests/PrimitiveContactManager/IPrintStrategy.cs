using System.Collections.Generic;

namespace Addressbook.Tests.PrimitiveContactManager
{
    public interface IPrintStrategy
    {
        string Execute(IEnumerable<string> formattedStrings);
    }
}