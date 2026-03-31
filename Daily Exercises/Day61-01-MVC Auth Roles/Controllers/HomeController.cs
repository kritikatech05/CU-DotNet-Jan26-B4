using CarManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace CarManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> SetupRoles()
        {
            string[] roles = { "Admin", "Customer", "User" };

            // 1. Create roles
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));

                    if (!roleResult.Succeeded)
                    {
                        return Content("Role creation failed: " +
                            string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                    }
                }
            }

            // 2. Find user
            var user = await _userManager.FindByEmailAsync("Kush@gmail.com");

            if (user == null)
            {
                return Content("❌ User NOT found");
            }

            // 3. Assign Admin role
            if (!await _userManager.IsInRoleAsync(user, "Admin"))
            {
                var result = await _userManager.AddToRoleAsync(user, "Admin");

                if (!result.Succeeded)
                {
                    return Content("❌ Role assignment failed: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }

            return Content("✅ Admin role assigned successfully!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}