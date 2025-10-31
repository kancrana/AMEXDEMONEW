using eShop.Domain.ProductCatalog;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Repository.EntityFramework.ProductCatalog.EntityConfiguration
{
    public class ProductTypeEntitiyConfiguration : EntityTypeConfiguration<ProductType>
    {
        public ProductTypeEntitiyConfiguration()
        {
            this.ToTable("ProductType");

            this.HasKey(ci => ci.Id);

            this.Property(ci => ci.Id)
               .IsRequired();

            this.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
