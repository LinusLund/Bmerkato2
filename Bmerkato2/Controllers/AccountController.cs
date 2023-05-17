using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerkato2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
