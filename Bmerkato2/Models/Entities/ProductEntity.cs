using Bmerkato2.Interfaces;
using Bmerkato2.Models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerkato2.Models.Entities
{
    public class ProductEntity : IProduct
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


        public static implicit operator Product(ProductEntity entity)
        {
            if (entity != null)
            {
                return new Product
                {
                    ArticleNumber = entity.ArticleNumber,
                    ProductName = entity.ProductName,
                    ProductDescription = entity.ProductDescription,
                    ProductPrice = entity.ProductPrice,
                    ProductCategory = entity.ProductCategory,
                    ImageUrl = entity.ImageUrl,

                };
            }
            return null!;
        }

    }
}

