using System;
using System.Linq.Expressions;
using Core.Enities;
using Specifications;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(p => p.ProductType);
            AddInclude(P => P.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id)
            : base (x => x.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(P => P.ProductBrand);
        }
    }
}