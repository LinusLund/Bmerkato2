using Bmerkato2.Helpers.Services;
using Bmerkato2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerkato2.Controllers
{
    public class RegisterController : Controller
    {

        private readonly AuthenticationService _auth;
        
            public RegisterController(AuthenticationService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM viewModel)
        {
            if (!viewModel.TermsAndAgreement)
            {
                ModelState.AddModelError("TermsAndAgreement", "You must agree with the terms and conditions");
            }

            if (ModelState.IsValid) 
            {
                if (await _auth.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
                    ModelState.AddModelError("", "An account with the same email already exists.");

                if (await _auth.RegisterUserAsync(viewModel))
                    return RedirectToAction("index","login");
            }
            return View(viewModel);
        }

    }
}
