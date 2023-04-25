using DAL.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Talabat.DTO
{

    public class ProductregDTO
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string publisher { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int ProductCategoryId { get; set; }

        public int ProductTypeId { get; set; }
        
    }
}
