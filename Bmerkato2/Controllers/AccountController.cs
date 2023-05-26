using Bmerkato2.Models.Identity;
using Bmerkato2.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
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
