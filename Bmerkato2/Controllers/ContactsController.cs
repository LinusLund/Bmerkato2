using Bmerkato2.Helpers.Services;
using Bmerkato2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerkato2.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactFormService _contactService;

        public ContactsController(ContactFormService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContactForm(ContactFormVM viewModel)
        {
            if (ModelState.IsValid)
            {
                await _contactService.AddAsync(viewModel);

                return RedirectToAction("Index");
            }
            return View(viewModel);

        }
    }
}
