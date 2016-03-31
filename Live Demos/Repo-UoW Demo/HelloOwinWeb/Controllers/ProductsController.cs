using System.Threading.Tasks;
using System.Web.Http;
using RepoUoW.Entities;
using RepoUoW.Patterns;
using RepoUoW.Patterns.EF;

namespace HelloOwinWeb.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        // HACK 1: Should be using DI but am too lazy right now
        //private readonly IProductRepository _productRepository
        //    = new ProductRepository(new Northwind());

        // HACK 2: Should be using DI but am too lazy right now
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController()
        {
            var dbContext = new Northwind();
            _unitOfWork = new UnitOfWork(dbContext, 
                new ProductRepository(dbContext));
        }

        //public ProductsController(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        // GET: api/Values
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            //var products = _productRepository.Retrieve();
            var products = await _unitOfWork.ProductRepository.Retrieve();
            return Ok(products);
        }

        // GET: api/Values/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var product = await _unitOfWork.ProductRepository.RetrieveById(id);
            return Ok(product);
        }

        // POST: api/Values
        [Route("", Name = "DefaultApi")]
        public async Task<IHttpActionResult> Post([FromBody]Product product)
        {
            _unitOfWork.ProductRepository.Insert(product);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", 
                new { id = product.ProductId }, product);
        }

        // PUT: api/Values/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return Ok(product);
        }

        // DELETE: api/Values/5
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _unitOfWork.ProductRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
