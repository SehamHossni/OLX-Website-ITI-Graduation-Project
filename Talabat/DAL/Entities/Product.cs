using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product:BaseEntity
    {
        public string Name{ get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string publisher { get; set; }
        public string PictureUrl { get; set; }
        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }
        [ForeignKey("ProductType ")]
        public int ProductTypeId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public   ProductType ProductType { get; set; }
        [JsonIgnore]
        public List<Comment>? comments { get; set; } 
    }
}
