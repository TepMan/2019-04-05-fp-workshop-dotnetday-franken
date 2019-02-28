using System.Collections.Generic;

namespace Addressbook.PrimitiveContactManager
{
    public interface IPrintStrategy
    {
        string Execute(IEnumerable<string> formattedStrings);
    }
}