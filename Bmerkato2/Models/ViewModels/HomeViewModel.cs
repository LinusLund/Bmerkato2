using Bmerkato2.Models.Entities;

internal class HomeViewModel
{
    public IEnumerable<ProductEntity>? NewProducts { get; set; }
    public IEnumerable<ProductEntity>? PopularProducts { get; set; }
    public IEnumerable<ProductEntity>? FeaturedProducts { get; set; }
}