using Bmerkato2.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Bmerkato2.Models.ViewModels
{
    public class ProductAddVM
    {
        public string ArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }


        public int SelectedCategoryId { get; set; } 


        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }

        public IEnumerable<SelectListItem>? CategorySelectList { get; set; }
        


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
                entity.ImageUrl = $"{Guid.NewGuid()}_{viewModel.Image?.FileName}";
            }

            return entity;



        }
    }
}
