using Bmerkato2.Helpers.Repos;
using Bmerkato2.Models.Dtos;
using Bmerkato2.Models.Entities;


namespace Bmerkato2.Helpers.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;
       
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly TagService _tagService;
        private readonly ProductTagRepository _productTagRepository;

        public ProductService(ProductRepository productRepo, IWebHostEnvironment webHostEnvironment, TagService tagService, ProductTagRepository productTagRepository)
        {
            _productRepo = productRepo;
            _webHostEnvironment = webHostEnvironment;
            _tagService = tagService;
            _productTagRepository = productTagRepository;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return await _productRepo.GetAllAsync();
        }

        public async Task<ProductEntity> CreateProductAsync(ProductEntity entity)
        {
            var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
            if (_entity == null)
            {
                _entity = await _productRepo.AddAsync(entity);
                if (_entity != null)
                    return entity;
            }
            return null!;
        }



        public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
        {
            foreach (var tag in tags)
            {
                await _productTagRepository.AddAsync(new ProductTagEntity
                {
                    ArticleNumber = entity.ArticleNumber,
                    TagId = int.Parse(tag),

                });
            }
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

        public async Task<ProductEntity> GetProductById(string articleNumber)
        {
            var product = await _productRepo.GetAsync(p => p.ArticleNumber == articleNumber);
            return product;
        }

         public async Task<IEnumerable<ProductEntity>> GetProductsByTag(string tagName)
        {
            var products = await _productRepo.GetAllAsync();
            return products.Where(p => p.ProductTags.Any(pt => pt.Tag.TagName == tagName));
        }

    }
}

