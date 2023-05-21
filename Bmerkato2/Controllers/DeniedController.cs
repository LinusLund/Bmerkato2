using Microsoft.AspNetCore.Mvc;

namespace Bmerkato2.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
