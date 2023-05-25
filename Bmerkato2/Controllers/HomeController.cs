using Bmerkato2.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller {

    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var newProducts = await _productService.GetProductsByTag("New");
        var popularProducts = await _productService.GetProductsByTag("Popular");
        var featuredProducts = await _productService.GetProductsByTag("Featured");

        var viewModel = new HomeViewModel
        {
            NewProducts = newProducts,
            PopularProducts = popularProducts,
            FeaturedProducts = featuredProducts
        };

        return View(viewModel);
    }


}
