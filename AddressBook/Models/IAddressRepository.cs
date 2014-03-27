using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
