using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AddressBook.Models
{
    public class AddressRepository : IAddressRepository
    {
        readonly AddressContext _db;

        public AddressRepository()
        {
            _db = new AddressContext();
        }

        public IEnumerable<Address> GetAll()
        {
            return _db.Address.ToList();
        }

        public Address Get(int id)
        {
            return _db.Address.SingleOrDefault(a => a.Id == id);
        }

        public Address Add(Address item)
        {
            Address address = _db.Address.Add(item);
            _db.SaveChanges();
            return address;
        }

        public void Remove(int id)
        {
            var address = _db.Address.SingleOrDefault(a => a.Id == id);
            _db.Address.Remove(address);
            _db.SaveChanges();
        }

        public bool Update(int id, Address item)
        {
            var address = _db.Address.SingleOrDefault(a => a.Id == id);
            if (address == null)
                throw new Exception(string.Format("Address with id: {0} not found", id));

            address.Street = item.Street;
            address.Zip = item.Zip;
            address.City = item.City;
            address.Country = item.Country;

            _db.Entry(address).State = EntityState.Modified;
            _db.SaveChanges();
            return true;
        }


    }
}