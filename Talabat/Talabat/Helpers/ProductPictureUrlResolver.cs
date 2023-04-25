using AutoMapper;
using DAL.Entities;
using Talabat.DTO;

namespace Talabat.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {

            if(!string.IsNullOrEmpty(source.PictureUrl)) {
               return $"{configuration["ApiUrl"]}{source.PictureUrl}";
            }
            return null;
        }
    }
}
