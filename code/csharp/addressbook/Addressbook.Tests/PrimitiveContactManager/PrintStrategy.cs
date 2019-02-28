using System.Collections.Generic;
using System.Linq;

namespace Addressbook.Tests.PrimitiveContactManager
{
    public class PrintStrategy : IPrintStrategy
    {
        public string Execute(IEnumerable<string> formattedStrings)
        {
            return formattedStrings.Aggregate((a, b) => $"{a},{b}");
        }
    }
}