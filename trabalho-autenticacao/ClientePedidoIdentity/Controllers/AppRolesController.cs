using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClientePedidoIdentity.Controllers;

public class AppRolesController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public AppRolesController(RoleManager<IdentityRole> roleManager) => _roleManager = roleManager;

    public IActionResult Index()
    {
        var roles = _roleManager.Roles;
        return View(roles);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(IdentityRole model)
    {
        if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();

        return RedirectToAction(nameof(Index));
    }

}
