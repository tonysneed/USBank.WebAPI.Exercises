using System.Collections.Generic;
using System.Threading.Tasks;
using RepoUoW.Entities;

namespace RepoUoW.Patterns
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Retrieve();

        Task<Product> RetrieveById(int productId);

        void Insert(Product product);

        void Update(Product product);

        Task Delete(int id);
    }
}
