using System.ComponentModel.DataAnnotations;

namespace Talabat.DTO
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(.1, double.MaxValue, ErrorMessage = "Price Must be Greater than zero!")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity Must be at least One!")]
        public int Quantity { get; set; }
        [Required]

        public string PictureUrl { get; set; }
        [Required]

        public string Brand { get; set; }
        [Required]

        public string Type { get; set; }
    }
}
