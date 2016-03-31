using System.Data.Entity.ModelConfiguration.Conventions;
using RepoUoW.Entities;

namespace RepoUoW.Patterns.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Northwind : DbContext
    {
        public Northwind()
            : base("name=Northwind")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);
        }
    }
}
