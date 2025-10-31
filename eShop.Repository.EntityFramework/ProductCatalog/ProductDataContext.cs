using eShop.Domain.ProductCatalog;
using eShop.Repository.EntityFramework.ProductCatalog.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Repository.EntityFramework.ProductCatalog
{
    public class ProductDataContext : DbContext
    {
        public DbSet<ProductBrand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public ProductDataContext() : base("ProductCatalog") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BrandEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductTypeEntitiyConfiguration());
        }

    }

}
