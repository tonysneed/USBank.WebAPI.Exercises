using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EFWebApiDemo.Data
{
    public partial class NorthwindSlim
    {
        partial void ModelCreatingHook(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure concurrency token
            modelBuilder.Entity<Product>()
                .Property(p => p.RowVersion).IsConcurrencyToken();
        }
    }
}
