using System;
using Addressbook.Persistence.Contracts;

namespace Addressbook.Persistence
{
    public class AddressbookProvider : IAddressbookProvider
    {
        public Addressbook GetAddressbook()
        {
            throw new NotImplementedException();
        }
    }
}