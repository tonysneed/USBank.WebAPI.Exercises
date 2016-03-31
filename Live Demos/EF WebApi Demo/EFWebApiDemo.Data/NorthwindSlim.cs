namespace EFWebApiDemo.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NorthwindSlim : DbContext
    {
        public NorthwindSlim()
            : base("name=NorthwindSlim")
        {
            // TODO: Put in T4 template
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelCreatingHook(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.RowVersion)
                .IsFixedLength();
        }

        partial void ModelCreatingHook(DbModelBuilder modelBuilder);
    }
}
