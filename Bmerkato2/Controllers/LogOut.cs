using Bmerkato2.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bmerkato2.Controllers
{
    public class LogOut : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogOut(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();

            return LocalRedirect("/");
        }
    }
}
