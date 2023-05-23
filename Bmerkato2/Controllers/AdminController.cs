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


        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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

                    var userViewModel = new UserVM
                    {
                        Id = user.Id,
                        FirstName = user.FirstName ?? string.Empty,
                        LastName = user.LastName ?? string.Empty,
                        Email = user.Email ?? string.Empty,
                        Role = role ?? string.Empty
                    };
                    users.Add(userViewModel);
                }
            }

            return View(users);
        }
    }
}
