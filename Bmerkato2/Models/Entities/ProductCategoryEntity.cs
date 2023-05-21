using Bmerkato2.Models.Entities;

public class ProductCategoryEntity
{
    public int Id { get; set; }

    public string CategoryName { get; set; }

    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();

}
