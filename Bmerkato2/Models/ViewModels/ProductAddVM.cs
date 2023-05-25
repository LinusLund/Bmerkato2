using Bmerkato2.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerkato2.Models.ViewModels
{
    public class ProductAddVM
    {
        [Required(ErrorMessage = "You must register an Article Number")]
        [Display(Name = "Article Number*")]
        public string ArticleNumber { get; set; } = null!;

        [Required(ErrorMessage = "You must register a Product Name")]
        [Display(Name = "Product Name*")]
        public string ProductName { get; set; } = null!;

        [Display(Name = "Product Description (Optional)")]
        public string? ProductDescription { get; set; }

        [Display(Name = "Price (Optional)")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }

        public int SelectedCategoryId { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }

        public IEnumerable<SelectListItem>? CategorySelectList { get; set; }

        [Display(Name = "Tags")]
        public List<string> Tags { get; set; } = new List<string>();
       
        
        public List<string>? SelectedTags { get; set; }




        public static implicit operator ProductEntity(ProductAddVM viewModel)
        {
            var entity = new ProductEntity
            {
                ArticleNumber = viewModel.ArticleNumber,
                ProductName = viewModel.ProductName,
                ProductDescription = viewModel.ProductDescription,
                ProductPrice = viewModel.ProductPrice,
                ProductCategoryId = viewModel.SelectedCategoryId,
                

            };

            if (viewModel.Image != null)
            {
                string uniqueFileName = $"{Guid.NewGuid()}_{viewModel.Image.FileName}";
                entity.ImageUrl = uniqueFileName;
            }

            return entity;
        }
    }
}