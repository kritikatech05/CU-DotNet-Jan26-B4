using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<IdentityUser> userManager,
                           RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // SHOW USERS IN TABLE
    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();
        var roles = _roleManager.Roles.Select(r => r.Name).ToList();

        var userRoles = new Dictionary<string, string>();

        foreach (var user in users)
        {
            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            userRoles[user.Id] = role;
        }

        ViewBag.Roles = roles;
        ViewBag.UserRoles = userRoles;

        return View(users);
    }

    // ASSIGN ROLE
    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> AssignRole(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);

        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);

        await _userManager.AddToRoleAsync(user, role);

        TempData["Success"] = "Role updated successfully!";
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Details(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        var roles = await _userManager.GetRolesAsync(user);

        ViewBag.Roles = roles;

        return View(user);
    }
}