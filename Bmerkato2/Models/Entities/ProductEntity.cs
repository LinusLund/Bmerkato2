using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerkato2.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;

        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }

        [Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }

        public string? ImageUrl { get; set; } 

        public int ProductCategoryId { get; set; }
        public ProductCategoryEntity ProductCategory { get; set; } = null!;

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();
    }
}

