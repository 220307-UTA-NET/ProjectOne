using BookStore.DataAccess;
using BookStore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Controllers
{
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _repo;

        public LocationController(ILocationRepository locationRepository)
        {
            _repo = locationRepository;
        }

        [HttpGet("api/locations")]
        public IActionResult GetAllLocations()
        {
            List<Models.Location> toReturn = new();
            var locations = _repo.GetAllLocations();
            foreach(var loc in locations)
            {
                Models.Location l = new();
                l.ID = loc.ID;
                l.Name = loc.Name;
                foreach(var kv in loc.Inventory)
                {
                    Models.InventoryProduct ip = new();
                    ip.ID = kv.Key.ID;
                    ip.Name = kv.Key.Name;
                    ip.Price = kv.Key.Price;
                    ip.Amount = kv.Value;
                    l.Inventory.Add(ip);
                }
                toReturn.Add(l);
            }
            return Ok(toReturn);
        }

        [HttpGet("api/locations/{id?}")]
        public IActionResult GetLocationByID(int id)
        {
            var loc = _repo.GetLocationByID(id);

            Models.Location l = new();
            l.ID = loc.ID;
            l.Name = loc.Name;
            foreach(var kv in loc.Inventory)
            {
                Models.InventoryProduct ip = new();
                ip.ID = kv.Key.ID;
                ip.Name = kv.Key.Name;
                ip.Price = kv.Key.Price;
                ip.Amount = kv.Value;
                l.Inventory.Add(ip);
            }

            return Ok(l);
        }

        [HttpPost("api/locations")]
        public void AddLocation(Models.Location l)
        {
            Domain.Location loc = new();
            loc.ID = l.ID;
            loc.Name = l.Name;
            foreach(var ip in l.Inventory)
            {
                Domain.Product p = new(ip.ID, ip.Name, ip.Price);
                loc.SetProductAmount(p, ip.Amount);
            }
            _repo.AddLocation(loc);
        }

        [HttpPut("api/locations")]
        public void UpdateLocation(Models.Location l)
        {
            Domain.Location loc = new();
            loc.ID = l.ID;
            loc.Name = l.Name;
            foreach (var ip in l.Inventory)
            {
                Domain.Product p = new(ip.ID, ip.Name, ip.Price);
                loc.SetProductAmount(p, ip.Amount);
            }
            _repo.UpdateLocation(loc);
        }
    }
}
