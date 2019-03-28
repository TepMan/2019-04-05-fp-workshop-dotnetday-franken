using System;
using System.Collections.Generic;

namespace Addressbook
{
    [Serializable]
    public class AddressbookOO
    {
        public List<ContactOO> Contacts { get; } = new List<ContactOO>();
        
        public void AddContact(ContactOO contact)
        {
            Contacts.Add(contact);
        }
    }
}