using Bmerkato2.Helpers.Repos;
using Bmerkato2.Models.Dtos;
using Bmerkato2.Models.Entities;

namespace Bmerkato2.Helpers.Services
{
    public class ProductCategoryService
    {
        private readonly ProductCategoryRepository _productCategoryRepo;

        public ProductCategoryService(ProductCategoryRepository productCategoryRepo)
        {
            _productCategoryRepo = productCategoryRepo;
        }

        public async Task<ProductCategory> CreateProductCategoryAsync(string categoryName)
        {
            var entity = new ProductCategoryEntity { CategoryName = categoryName };
            var result = await _productCategoryRepo.AddAsync(entity);

            return result;

        }

        public async Task<ProductCategoryEntity> GetCategoryAsync(string categoryName)
        {
            var result = await _productCategoryRepo.GetAsync(x => x.CategoryName == categoryName);
            return result;
        }

        public async Task<ProductCategoryEntity> GetCategoryAsync(int id)
        {
            var result = await _productCategoryRepo.GetAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync()
        {
            var result = await _productCategoryRepo.GetAllAsync();


            var list = new List<ProductCategory>();
            foreach (var category in result)
                list.Add(category);

            return list;
        }

        public async Task AssociateProductWithCategoryAsync(ProductEntity product, int id)
        {
            var category = await _productCategoryRepo.GetAsync(x => x.Id == id);
            if (category != null)
            {
                product.ProductCategory = category;
            }
        }
    }
}
