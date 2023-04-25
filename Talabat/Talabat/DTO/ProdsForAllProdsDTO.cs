namespace Talabat.DTO
{
    public class ProdsForAllProdsDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string publisher { get; set; }
        public string? publisherdispname { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int ProductCategoryId { get; set; }

        public int ProductTypeId { get; set; }
        public string ProductCategory { get; set; }
        public string ProductType { get; set; }
    }
}
