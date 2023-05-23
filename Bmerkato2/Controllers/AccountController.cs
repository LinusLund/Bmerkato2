using Microsoft.AspNetCore.Mvc;

namespace Bmerkato2.Controllers
{

    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
