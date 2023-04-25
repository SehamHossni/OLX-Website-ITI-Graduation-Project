using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
