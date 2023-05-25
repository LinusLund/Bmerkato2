using Bmerkato2.Helpers.Services;
using Bmerkato2.Models.Entities;
using Bmerkato2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Bmerkato2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly ProductCategoryService _productCategoryService;
        private readonly TagService _tagService;

        public ProductsController(ProductService productService, ProductCategoryService productCategoryService, TagService tagService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _tagService = tagService;
        }


        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            

            return View(products);
        }

        public async Task<IActionResult> Add()
        {
            //populerar Taglistan och Kategorilistan innan ViewModel returneras.
            var selectedTags = new string[] { }; 
            ViewBag.Tags = await _tagService.GetTagsAsync(selectedTags);


            var viewModel = new ProductAddVM();

            var categories = await _productCategoryService.GetCategoriesAsync();
            viewModel.CategorySelectList = new SelectList(categories, "Id", "CategoryName");

            



            return View(viewModel);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(ProductAddVM viewModel, string[] tags)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateProductAsync(viewModel);
                if (product != null)
                {
                    if (viewModel.Image != null)
                        await _productService.UploadImageAsync(product, viewModel.Image);

                    await _productService.AddProductTagsAsync(viewModel, tags);

                    return RedirectToAction("Add");

                }

                ModelState.AddModelError("", "Something Went Wrong.");
            }
            var categories = await _productCategoryService.GetCategoriesAsync();
            viewModel.CategorySelectList = new SelectList(categories, "Id", "CategoryName");

            ViewBag.Tags = await _tagService.GetTagsAsync(tags);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string articleNumber)
        {
            var product = await _productService.GetProductById(articleNumber);

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailsVM
            {
                ArticleNumber = product.ArticleNumber,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductDescription = product.ProductDescription,
                ImageUrl = product.ImageUrl,
            };
            

            return View("Details",viewModel);
        }
    }
}