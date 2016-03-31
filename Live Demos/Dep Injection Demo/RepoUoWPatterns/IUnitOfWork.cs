using System.Threading.Tasks;

namespace RepoUoW.Patterns
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
