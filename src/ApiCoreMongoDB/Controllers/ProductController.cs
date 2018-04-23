using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCoreMongoDB.Interfaces;
using ApiCoreMongoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreMongoDB.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository ProductRepository)
        {
            _repo = ProductRepository;
        }


        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _repo.GetAllProducts());
        }


        // GET: api/Product/name
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            var Product = await _repo.GetProduct(name);
            if (Product == null)
                return new NotFoundResult();
            return new ObjectResult(Product);
        }


        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product Product)
        {
            await _repo.Create(Product);
            return new OkObjectResult(Product);
        }


        // PUT: api/Product/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]Product Product)
        {
            var ProductFromDb = await _repo.GetProduct(name);
            if (ProductFromDb == null)
                return new NotFoundResult();
            Product.Id = ProductFromDb.Id;
            await _repo.Update(Product);
            return new OkObjectResult(Product);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var ProductFromDb = await _repo.GetProduct(name);
            if (ProductFromDb == null)
                return new NotFoundResult();
            await _repo.Delete(name);
            return new OkResult();
        }

    }
}