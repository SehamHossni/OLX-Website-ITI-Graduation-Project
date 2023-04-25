using AutoMapper;
using DAL.Entities;
using Talabat.DTO;

namespace Talabat.Helpers
{
    public class ProductPictureUrlResolverforallprods : IValueResolver<Product, ProdsForAllProdsDTO, string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrlResolverforallprods(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProdsForAllProdsDTO destination, string destMember, ResolutionContext context)
        {

            if(!string.IsNullOrEmpty(source.PictureUrl)) {
               return $"{configuration["ApiUrl"]}{source.PictureUrl}";
            }
            return null;
        }
    }
}
