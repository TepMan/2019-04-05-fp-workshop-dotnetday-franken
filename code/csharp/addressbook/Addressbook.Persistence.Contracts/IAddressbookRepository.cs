namespace Addressbook.Persistence.Contracts
{
    public interface IAddressbookRepository
    {
        AddressbookOO GetAddressbook();
        void Save(AddressbookOO addressbook);
    }
}