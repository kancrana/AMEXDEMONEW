using eShop.Domain.ProductCatalog;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Repository.EntityFramework.ProductCatalog.EntityConfiguration
{
    public class ProductEntityTypeConfiguration: EntityTypeConfiguration<Product>
    {
        public ProductEntityTypeConfiguration()
        {
            this.ToTable("Product");
            this.Property(c => c.Id).IsRequired();
            this.Property(c => c.Name).IsRequired().HasMaxLength(100);
            this.Property(ci => ci.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(ci => ci.Price)
                .IsRequired();

            this.Property(ci => ci.PictureFileName)
                .IsRequired();

            this.Ignore(ci => ci.PictureUri);

            this.HasRequired(ci => ci.Brand)
                .WithMany()
                .HasForeignKey(ci => ci.ProductBrandId);

            this.HasRequired(ci => ci.ProductType)
                .WithMany()
                .HasForeignKey(ci => ci.ProductTypeId);
        }
    }
}
