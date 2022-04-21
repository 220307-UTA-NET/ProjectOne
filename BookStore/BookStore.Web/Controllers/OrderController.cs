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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repo;

        public OrderController(IOrderRepository orderRepository)
        {
            _repo = orderRepository;
        }

        [HttpGet("api/orders")]
        public IActionResult GetAllOrders()
        {
            List<Models.Order> toReturn = new();
            var orders = _repo.GetAllOrders();
            foreach(var order in orders)
            {
                Models.Order o = new();
                o.ID = order.ID;
                o.CustomerID = order.CustomerID;
                o.LocationID = order.LocationID;
                o.Time = order.Time;
                o.Total = order.Total;
                foreach(var kv in order.Items)
                {
                    Models.InventoryProduct ip = new();
                    ip.ID = kv.Key.ID;
                    ip.Name = kv.Key.Name;
                    ip.Price = kv.Key.Price;
                    ip.Amount = kv.Value;
                    o.Items.Add(ip);
                }
                toReturn.Add(o);
            }
            return Ok(toReturn);
        }

        [HttpGet("api/orders/{id?}")]
        public IActionResult GetOrderByID(int id)
        {
            var order = _repo.GetOrderByID(id);

            Models.Order o = new();
            o.ID = order.ID;
            o.CustomerID = order.CustomerID;
            o.LocationID = order.LocationID;
            o.Time = order.Time;
            o.Total = order.Total;
            foreach (var kv in order.Items)
            {
                Models.InventoryProduct ip = new();
                ip.ID = kv.Key.ID;
                ip.Name = kv.Key.Name;
                ip.Price = kv.Key.Price;
                ip.Amount = kv.Value;
                o.Items.Add(ip);
            }

            return Ok(o);
        }

        [HttpPost("api/orders")]
        public IActionResult AddOrder(Models.Order o)
        {
            if(o == null)
            {
                return BadRequest();
            }

            Domain.Order order = new();
            order.ID = o.ID;
            order.CustomerID = o.CustomerID;
            order.LocationID = o.LocationID;
            order.Time = o.Time;
            foreach(var ip in o.Items)
            {
                Domain.Product p = new(ip.ID, ip.Name, ip.Price);
                order.SetItemAmount(p, ip.Amount);
            }
            
            _repo.AddOrder(order);
            
            return Ok();
        }

        [HttpPut("api/orders")]
        public IActionResult UpdateOrder(Models.Order o)
        {
            if (o == null)
            {
                return BadRequest();
            }

            Domain.Order order = new();
            order.ID = o.ID;
            order.CustomerID = o.CustomerID;
            order.LocationID = o.LocationID;
            order.Time = o.Time;
            foreach (var ip in o.Items)
            {
                Domain.Product p = new(ip.ID, ip.Name, ip.Price);
                order.SetItemAmount(p, ip.Amount);
            }
            
            _repo.UpdateOrder(order);

            return Ok();
        }

        [HttpGet("api/locations/{id?}/orders")]
        public IActionResult GetOrdersByLocationID(int id)
        {
            List<Models.Order> toReturn = new();
            var orders = _repo.GetOrdersByLocationID(id);
            foreach (var order in orders)
            {
                Models.Order o = new();
                o.ID = order.ID;
                o.CustomerID = order.CustomerID;
                o.LocationID = order.LocationID;
                o.Time = order.Time;
                o.Total = order.Total;
                foreach (var kv in order.Items)
                {
                    Models.InventoryProduct ip = new();
                    ip.ID = kv.Key.ID;
                    ip.Name = kv.Key.Name;
                    ip.Price = kv.Key.Price;
                    ip.Amount = kv.Value;
                    o.Items.Add(ip);
                }
                toReturn.Add(o);
            }
            return Ok(toReturn);
        }

        [HttpGet("api/customers/{id?}/orders")]
        public IActionResult GetOrdersByCustomerID(int id)
        {
            List<Models.Order> toReturn = new();
            var orders = _repo.GetOrdersByCustomerID(id);
            foreach (var order in orders)
            {
                Models.Order o = new();
                o.ID = order.ID;
                o.CustomerID = order.CustomerID;
                o.LocationID = order.LocationID;
                o.Time = order.Time;
                o.Total = order.Total;
                foreach (var kv in order.Items)
                {
                    Models.InventoryProduct ip = new();
                    ip.ID = kv.Key.ID;
                    ip.Name = kv.Key.Name;
                    ip.Price = kv.Key.Price;
                    ip.Amount = kv.Value;
                    o.Items.Add(ip);
                }
                toReturn.Add(o);
            }
            return Ok(toReturn);
        }
    }
}
