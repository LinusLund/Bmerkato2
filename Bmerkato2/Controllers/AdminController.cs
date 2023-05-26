using Bmerkato2.Helpers.Services;
using Bmerkato2.Models.Identity;
using Bmerkato2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace Bmerkato2.Controllers
{


    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AuthenticationService _authenticationService;


        public AdminController(UserManager<AppUser> userManager, AuthenticationService authenticationService)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult ViewUsers()
        {
            var users = new List<UserVM>();

            var userManager = HttpContext.RequestServices.GetService(typeof(UserManager<AppUser>)) as UserManager<AppUser>;
            var roleManager = HttpContext.RequestServices.GetService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>;

            if (userManager != null && roleManager != null)
            {
                foreach (var user in userManager.Users.ToList())
                {
                    var roles = userManager.GetRolesAsync(user).Result;
                    var role = roles.FirstOrDefault();

                    UserVM userViewModel = user;

                    userViewModel.Role = role ?? string.Empty; 

                    users.Add(userViewModel);
                }
            }

            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddUser()
        {
            var viewModel = new UserRegisterVM();

            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserRegisterVM viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _authenticationService.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
                    ModelState.AddModelError("", "An account with the same email already exists.");

                if (await _authenticationService.RegisterUserAsync(viewModel))
                    return RedirectToAction("index", "admin");
            }
            return View(viewModel);
        }

        public async Task<IActionResult> UpdateUser(string userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("ViewUsers");
            }
            var currentRoles = await _userManager.GetRolesAsync(user);

            if (!string.IsNullOrEmpty(newRole) && !currentRoles.Contains(newRole))
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, newRole);
            }

            return RedirectToAction("ViewUsers");
        }
    }
}
