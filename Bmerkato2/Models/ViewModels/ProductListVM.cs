using Bmerkato2.Models.Dtos;

namespace Bmerkato2.Models.ViewModels
{
    public class ProductListVM
    {
        public string ArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ImageUrl { get; set; }

        public ProductCategory ProductCategory { get; set; } = null!;
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        
       
    }
}
