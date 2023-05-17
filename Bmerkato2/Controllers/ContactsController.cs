using Microsoft.AspNetCore.Mvc;

namespace Bmerkato2.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
