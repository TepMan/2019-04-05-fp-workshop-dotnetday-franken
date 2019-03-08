using System;
using System.Collections.Generic;

namespace Addressbook
{
    [Serializable]
    public class Addressbook
    {
        public List<Contact> Contacts { get; } = new List<Contact>();
        
        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }
    }
}