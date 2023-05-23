using Bmerkato2.Helpers.Services;
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

        public ProductsController(ProductService productService, ProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }


        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            
            return View(products);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async  Task<IActionResult> Add()
        {
            var viewModel =  new ProductAddVM();

            var categories = await _productCategoryService.GetCategoriesAsync();
            viewModel.CategorySelectList = new SelectList(categories, "Id", "CategoryName");


            return View(viewModel);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(ProductAddVM viewModel)
        {
            
            if (ModelState.IsValid)
            {
                var product = viewModel;
                var createdProduct = await _productService.CreateProductAsync(product);
                if (createdProduct != null)
                {
                    if (viewModel.Image != null) 
                    {
                        await _productService.UploadImageAsync(createdProduct, viewModel.Image);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the product.");
                }
            }

            return View("Add", viewModel); 
        }
    }
}