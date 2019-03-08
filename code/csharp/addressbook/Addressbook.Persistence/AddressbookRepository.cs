using System;
using System.IO;
using Addressbook.Persistence.Contracts;
using Newtonsoft.Json;

namespace Addressbook.Persistence
{
    public class AddressbookRepository : IAddressbookRepository
    {
        private const string FALLBACK_ADDRESSBOOK_JSON = @"~/tmp/addressbook.json";
        private readonly string _addressbookJson;

        public AddressbookRepository(string addressbookJson)
        {
            _addressbookJson = string.IsNullOrWhiteSpace(addressbookJson)
                ? FALLBACK_ADDRESSBOOK_JSON
                : addressbookJson;
        }

        public Addressbook GetAddressbook()
        {
            using (var file = File.OpenText(_addressbookJson))
            {
                var serializer = new JsonSerializer();
                var addressbook = (Addressbook)serializer.Deserialize(file, typeof(Addressbook));
                return addressbook;
            }
        }

        public void Save(Addressbook addressbook)
        {
            using (var file = File.CreateText(_addressbookJson))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, addressbook);
            }
        }
    }
}