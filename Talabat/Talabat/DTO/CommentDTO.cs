using DAL.Entities;
using Newtonsoft.Json;

namespace Talabat.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }

        //[ForeignKey("Product")]
        public int ProductID { get; set; }
    }
}
