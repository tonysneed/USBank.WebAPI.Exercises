using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RepoUoW.Entities;

namespace RepoUoW.Patterns.EF
{
    public class ProductRepository : IProductRepository
    {
        private readonly Northwind _dbContext;

        public ProductRepository(Northwind dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> Retrieve()
        {
            var products = await _dbContext.Products
                .OrderBy(p => p.ProductName)
                .ToListAsync();
            return products;
        }

        public async Task<Product> RetrieveById(int productId)
        {
            var product = await _dbContext.Products
                .SingleOrDefaultAsync(p => p.ProductId == productId);
            return product;
        }

        public void Insert(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Added;
        }

        public void Update(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var product = await RetrieveById(id);
            _dbContext.Entry(product).State = EntityState.Deleted;
        }
    }
}
