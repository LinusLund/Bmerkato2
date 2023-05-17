using Bmerkato2.Helpers.Services;
using Bmerkato2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerkato2.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthenticationService _auth;

        public LoginController(AuthenticationService auth)
        {
            _auth = auth;
        }

        public IActionResult Index(string ReturnUrl = null!)
        {
            var viewModel = new UserLoginVM();
            if(ReturnUrl != null)
                viewModel.ReturnUrl = ReturnUrl;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginVM viewModel)
        {
            if(ModelState.IsValid) 
            { 
                if( await _auth.LoginASync(viewModel))
                return LocalRedirect(viewModel.ReturnUrl);

                ModelState.AddModelError("", "Incorrect e-mail or password ");
            }

            
            return View(viewModel);
            
        }
    }
}
