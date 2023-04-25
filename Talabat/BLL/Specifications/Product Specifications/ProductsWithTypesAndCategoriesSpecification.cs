using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.BLL.Specifications;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications
{
    public class ProductsWithTypesAndCategoriesSpecification : BaseSpecification<Product>
    {
        /// This Constructor Use When Need to Get All Products
        public ProductsWithTypesAndCategoriesSpecification(ProductSpecParams productParams)
            :base(P => 
                    (string.IsNullOrEmpty(productParams.Search) || P.Name.ToLower().Contains(productParams.Search)) &&
                    (!productParams.CategoryId.HasValue || P.ProductCategoryId == productParams.CategoryId.Value) &&
                    (!productParams.TypeId.HasValue || P.ProductTypeId == productParams.TypeId.Value))
        {
            AddInclude(P => P.ProductType);
            AddInclude(P => P.ProductCategory);
            AddOrderBy(P => P.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch(productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
        }

        /// This Constructor Use When Need to Get a Specific Product With Id
        public ProductsWithTypesAndCategoriesSpecification(int id):base(P => P.Id == id)
        {
            AddInclude(P => P.ProductType);
            AddInclude(P => P.ProductCategory);
            AddInclude(P => P.comments);
        }

        //This Constructor Use When Need to Get a Specific Products With catigoryid and we don't use type it isn't neccesary
        public ProductsWithTypesAndCategoriesSpecification(int categoryId,int prodtype)
        : base(p => p.ProductCategoryId == categoryId)
        {
            AddInclude(P => P.ProductType);
            AddInclude(P => P.ProductCategory);
            

        }

        //this constructor is to get products by a vendor
        public ProductsWithTypesAndCategoriesSpecification(string vendorname)
        : base(p => p.publisher == vendorname)
        {
            AddInclude(P => P.ProductType);
            AddInclude(P => P.ProductCategory);


        }


    }
}
