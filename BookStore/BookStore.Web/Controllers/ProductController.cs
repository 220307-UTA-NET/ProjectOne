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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository productRepository)
        {
            _repo = productRepository;
        }

        [HttpGet("api/products")]
        public IEnumerable<Domain.Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        [HttpGet("api/products/{id?}")]
        public Domain.Product GetProductByID(int id)
        {
            return _repo.GetProductByID(id);
        }
    }
}
