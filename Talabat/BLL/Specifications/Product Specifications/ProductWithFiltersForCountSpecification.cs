using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Talabat.BLL.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
            : base(P =>
                    (string.IsNullOrEmpty(productParams.Search) || P.Name.ToLower().Contains(productParams.Search)) &&
                     (!productParams.CategoryId.HasValue || P.ProductCategoryId == productParams.CategoryId.Value) &&
                     (!productParams.TypeId.HasValue || P.ProductTypeId == productParams.TypeId.Value))
        {
        }
    }
}