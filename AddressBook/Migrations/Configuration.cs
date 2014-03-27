namespace AddressBook.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Data.Entity.Spatial;

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
                new Address { Id = 1, Name = "La Casa", Street = "Skrukkerødtoppen 10", Zip = "3924", City = "Porsgrunn", Location = DbGeography.FromText("POINT(009.6604833 59.1234917)", 4326) },
                new Address { Id = 2, Name = "Recent", Street = "Snekkeråsvegen 20", Zip = "3946", City = "Porsgrunn"   , Location = DbGeography.FromText("POINT(010.2530750 59.1794028)", 4326) },
                new Address { Id = 3, Name = "Stangs", Street = "Stangsgate 15", Zip = "3916", City = "Porsgrunn"       , Location = DbGeography.FromText("POINT(009.6555333 59.1388306)", 4326) },
                new Address { Id = 4, Name = "Guri", Street = "Høyåsvegen 8", Zip = "3919", City = "Porsgrunn"          , Location = DbGeography.FromText("POINT(010.7524889 59.9140000)", 4326) },
                /*
                geography::STGeomFromText('POINT(009.6604833 59.1234917)', 4326)
                geography::STGeomFromText('POINT(010.2530750 59.1794028)', 4326)
                geography::STGeomFromText('POINT(009.6555333 59.1388306)', 4326)
                geography::STGeomFromText('POINT(010.7524889 59.9140000)', 4326)
                */
            };

            addresses.ForEach(c => context.Address.AddOrUpdate(a => a.Id, c));
            context.SaveChanges();
        }
    }
}
