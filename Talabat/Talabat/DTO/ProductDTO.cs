using DAL.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Talabat.DTO
{

    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string publisher { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int ProductCategoryId { get; set; }

        public int ProductTypeId { get; set; }
        public string ProductCategory { get; set; }
        public string ProductType { get; set; }
        public string? PubliserName { get; set; }
        [JsonIgnore]
        public List<CommentsSectionDTO>? comments{ get; set; }
    }
}
