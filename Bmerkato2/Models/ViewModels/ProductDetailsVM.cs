namespace Bmerkato2.Models.ViewModels
{
    public class ProductDetailsVM
    {               
        public string ArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public decimal? ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public string? ImageUrl { get; set; }
        
    }
}
