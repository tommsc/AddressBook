namespace AddressBook.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AddressBook.Models.AddressContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AddressBook.Models.AddressContext context)
        {
            var addresses = new List<Address> 
            {
                new Address { Id = 1, Street = "Skrukkerødtoppen 10", Zip = "3924", City = "Porsgrunn" },
                new Address { Id = 2, Street = "Snekkeråsvegen 20", Zip = "3946", City = "Porsgrunn" },
                new Address { Id = 3, Street = "Stangsgate 15", Zip = "3916", City = "Porsgrunn" },
                new Address { Id = 4, Street = "Høyåsvegen 8", Zip = "3919", City = "Porsgrunn" },
            };

            addresses.ForEach(c => context.Address.AddOrUpdate(a => a.Id, c));
            context.SaveChanges();
        }
    }
}
