using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsAPI.Controllers {

    public class ProductsController : ApiController {


        //Probably a database in a real scenario...
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        // GET: api/Products
        public IEnumerable<Product> GetAllProducts() {
            return products;
        }

        // GET: api/Products/5
        [Route("api/products/{id:int}")]
        public IHttpActionResult GetProduct(int id) {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null) {
                return NotFound();
            }
            return Ok(product); //Respecting HTTP errors (200 OK)
        }

        // GET: api/Products/5
        [Route("api/products/{category}")]
        public IHttpActionResult GetCategories(string category) {
            var product = products.FindAll((p) => p.Category == category);
            if (product == null) {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Products
        public void Post([FromBody] string value) {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE: api/Products/5
        public void Delete(int id) {
        }
    }
}
