using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookStore.DataAccess
{
    public class LocationRepository : ILocationRepository
    {
        private readonly BookStoreDbContext _context;
        public LocationRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        // CRUD Location

        /// <summary>
        /// Returns the list of all Locations from the database.
        /// </summary>
        /// <returns> List<Location> toReturn </returns>
        public List<Domain.Location> GetAllLocations()
        {
            var dbLocations = _context.Set<Location>().ToList();
            List<Domain.Location> toReturn = new List<Domain.Location>();

            foreach (var l in dbLocations)
            {
                var n = new Domain.Location(l.Id) { Name = l.Name };
                var inventories = _context.Set<Inventory>().Where(i => i.LocationId == l.Id).ToList();
                foreach (var i in inventories)
                {
                    var dbProduct = _context.Set<Product>().Where(p => p.Id == i.ProductId).FirstOrDefault();
                    var domProduct = new Domain.Product(dbProduct.Id, dbProduct.Name, (decimal)dbProduct.Price);
                    n.SetProductAmount(domProduct, i.Amount);
                }
                toReturn.Add(n);
            }

            return toReturn;
        }

        /// <summary>
        /// Returns the specific Location matching the given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Location loc </returns>
        public Domain.Location GetLocationByID(int id)
        {
            var l = _context.Set<Location>().Find(id);
            Domain.Location loc = new Domain.Location(id) { Name = l.Name };

            var inventories = _context.Set<Inventory>().Where(i => i.LocationId == id).ToList();
            foreach (var i in inventories)
            {
                var dbProduct = _context.Set<Product>().Where(p => p.Id == i.ProductId).FirstOrDefault();
                var domProduct = new Domain.Product(dbProduct.Id, dbProduct.Name, (decimal)dbProduct.Price);
                loc.SetProductAmount(domProduct, i.Amount);
            }

            return loc;
        }

        /// <summary>
        /// Returns the specific Location matching the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns> Location loc </returns>
        public Domain.Location GetLocationByName(string name)
        {
            var l = _context.Set<Location>().Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            Domain.Location loc = new Domain.Location(l.Id) { Name = l.Name };

            var inventories = _context.Set<Inventory>().Where(i => i.LocationId == loc.ID).ToList();
            foreach (var i in inventories)
            {
                var dbProduct = _context.Set<Product>().Where(p => p.Id == i.ProductId).FirstOrDefault();
                var domProduct = new Domain.Product(dbProduct.Id, dbProduct.Name, (decimal)dbProduct.Price);
                loc.SetProductAmount(domProduct, i.Amount);
            }

            return loc;
        }

        /// <summary>
        /// Adds the given Location to the database.
        /// </summary>
        /// <param name="l"></param>
        public void AddLocation(Domain.Location l)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the given Location in the database.
        /// </summary>
        /// <param name="l"></param>
        public void UpdateLocation(Domain.Location l)
        {
            var entity = _context.Locations.SingleOrDefault(x => x.Id == l.ID);
            if (entity != null)
            {
                entity.Name = l.Name;
                _context.Entry(entity).State = EntityState.Modified;

                foreach (KeyValuePair<Domain.Product, int> kv in l.Inventory)
                {
                    var i = _context.Find<Inventory>(l.ID, kv.Key.ID);
                    if (i.Amount != kv.Value)
                    {
                        i.Amount = kv.Value;
                        _context.Entry(i).State = EntityState.Modified;
                    }
                }

                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the given Location from the database.
        /// </summary>
        /// <param name="l"></param>
        public void DeleteLocation(Domain.Location l)
        {
            throw new NotImplementedException();
        }
    }
}
