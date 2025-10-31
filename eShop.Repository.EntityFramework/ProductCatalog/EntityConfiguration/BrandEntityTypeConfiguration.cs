using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using eShop.Domain.ProductCatalog;

namespace eShop.Repository.EntityFramework.ProductCatalog.EntityConfiguration
{
    public class BrandEntityTypeConfiguration : EntityTypeConfiguration<ProductBrand>
    {
        public BrandEntityTypeConfiguration()
        {
            this.ToTable("ProductBrand");
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).IsRequired();
            this.Property(c => c.Name).IsRequired().HasMaxLength(100);
        }
    }
}
