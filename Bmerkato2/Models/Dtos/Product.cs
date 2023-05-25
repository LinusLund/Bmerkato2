namespace Bmerkato2.Models.Dtos
{
    public class Product
    {
        public string ArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        public ProductCategory ProductCategory { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public List<string> Tags { get; set; } = new List<string>();
    }
}
