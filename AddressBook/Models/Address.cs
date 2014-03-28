using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Diagnostics;

namespace AddressBook.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public DbGeography Location { get; set; } 
    }

    public class AddressBookContext : DbContext
    {
        public AddressBookContext()
        {
            Debug.Write(Database.Connection.ConnectionString);
        }
        public DbSet<Address> Address { get; set; }
    }

}