using System.Collections.Generic;

namespace AddressBook.Models
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        Address Get(int id);
        Address Add(Address item);
        void Remove(int id);
        bool Update(int id, Address item);
    }
}
