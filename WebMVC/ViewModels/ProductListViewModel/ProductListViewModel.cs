using System.Collections.Generic;
using eShop.Web.ViewModels;

namespace eShop.Web.ViewModels.ProductListViewModel
{
    public class ProductListViewModel
    {
        public ProductList ProductList { get; set; }
        public List<ProductBrand> ProductBrands { get; set; }
        public List<ProductType> ProductTypes { get; set; }
    }
}