using Bmerkato2.Models.Dtos;

namespace Bmerkato2.Models.ViewModels
{
    public class ProductListVM
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
