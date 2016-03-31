using System;
using System.Threading.Tasks;

namespace RepoUoW.Patterns.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;
        private readonly Northwind _dbContext;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(Northwind dbContext,
            IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            // Safely cast to IDisposable, then call Dispose
            if (_disposed) return;
            var disposable = _dbContext as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
                _disposed = true;
            }
        }
    }
}
