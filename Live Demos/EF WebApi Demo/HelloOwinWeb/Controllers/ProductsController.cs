using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Http;
using EFWebApiDemo.Data;

namespace HelloOwinWeb.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        NorthwindSlim _dbContext = new NorthwindSlim();

        // GET api/<controller>
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var products = await _dbContext.Products
                .Include(p => p.Category)
                .OrderBy(p => p.ProductName)
                .ToListAsync();
            return Ok(products);
        }

        // GET api/<controller>/5
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var product = await _dbContext.Products
                .SingleOrDefaultAsync(p => p.ProductId
                    == id);
            return Ok(product);
        }

        // POST api/<controller>
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]Product product)
        {
            _dbContext.Entry(product).State = EntityState.Added;

            await _dbContext.SaveChangesAsync();

            return Ok(product);
        }

        // PUT api/<controller>/5
        [Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;

            using (var scope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted,
                    Timeout = TimeSpan.FromMinutes(2)
                }))
            {
                await _dbContext.SaveChangesAsync();
                scope.Complete();
            }

            return Ok(product);
        }

        // DELETE api/<controller>/5
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var product = await _dbContext.Products
                .SingleOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
                return NotFound();

            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}