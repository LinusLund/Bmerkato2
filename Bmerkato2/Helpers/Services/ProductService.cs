using Bmerkato2.Helpers.Repos;
using Bmerkato2.Models.Dtos;
using Bmerkato2.Models.Entities;
using Bmerkato2.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace Bmerkato2.Helpers.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;
        private readonly ProductCategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(ProductRepository productRepo, ProductCategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _productRepo = productRepo;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return await _productRepo.GetAllAsync();
        }

        public async Task<ProductEntity> CreateProductAsync(ProductAddVM product)
        {
            
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            if (string.IsNullOrEmpty(product.ArticleNumber))
            {
                throw new ArgumentException("Article number is required.", nameof(product.ArticleNumber));
            }

            if (string.IsNullOrEmpty(product.ProductName))
            {
                throw new ArgumentException("Product name is required.", nameof(product.ProductName));
            }

            
            var productEntity = (ProductEntity)product;

           
            var selectedCategory = await _categoryService.GetCategoryAsync(product.SelectedCategoryId);

         
            if (selectedCategory != null)
            {
                productEntity.ProductCategory = selectedCategory;
            }

           
            var createdProduct = await _productRepo.AddAsync(productEntity);

            return createdProduct;
        }

        public async Task<bool> UploadImageAsync(Product product, IFormFile image)
        {
            try
            {
                string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
                await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
                return true;
            }
            catch { return false; }
        }
    }
}
