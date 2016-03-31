using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    public class ProductsController : ApiController
    {
        Dictionary<int, Product> _products = new Dictionary<int, Product>
        {
            { 1, new Product { Id = 1, ProductName = "Chai", Price = 10 } },
            { 2, new Product { Id = 2, ProductName = "Chang", Price = 20 } },
            { 3, new Product { Id = 3, ProductName = "Chow", Price = 30 } },
        };

        // GET: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            return Ok(_products.Values);
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            return Ok(_products[id]);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody]Product product)
        {
            _products.Add(product.Id, product);
            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            if (!_products.ContainsKey(id))
                return NotFound();
            _products[id] = product;
            return Ok(product);
        }

        // DELETE: api/Products/5
        public IHttpActionResult Delete(int id)
        {
            if (!_products.ContainsKey(id))
                return NotFound();
            _products.Remove(id);
            return Ok();
        }
    }
}
