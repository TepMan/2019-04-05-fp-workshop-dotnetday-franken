namespace Addressbook.Persistence.Contracts
{
    public interface IAddressbookRepository
    {
        Addressbook GetAddressbook();
        void Save(Addressbook addressbook);
    }
}