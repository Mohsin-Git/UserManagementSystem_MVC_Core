using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Application.DTO;
using UserManagementSystem.Application.IServices;

[Authorize]
public class RoleController : Controller
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var vm = new RoleIndexDTO
        {
            Roles = await _roleService.GetAllRolesAsync(),
            Role = new RoleRequestDTO()
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RoleIndexDTO model)
    {
        // model.Role.RoleName wo naam hai jo form se aa raha hai
        if (!ModelState.IsValid)
        {
            // Error ki surat mein list ko dobara load karein (Objects ke saath)
            model.Roles = await _roleService.GetAllRolesAsync();
            return View("Index", model);
        }

        // Role create karne ke liye service call karein
        var success = await _roleService.CreateNewRoleAsync(model.Role.RoleName);

        if (!success)
        {
            ModelState.AddModelError("Role.RoleName", "This role already exists.");
            // List ko dobara load karein
            model.Roles = await _roleService.GetAllRolesAsync();
            return View("Index", model);
        }

        TempData["Success"] = "Role created successfully!";
        return RedirectToAction(nameof(Index));
    }
     
    // POST: Role/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        await _roleService.DeleteRoleAsync(id);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        if (string.IsNullOrEmpty(id)) return NotFound();

        var role = await _roleService.GetRoleByIdAsync(id);
        if (role == null) return NotFound();

        return View(role);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(RoleIndexDTO model)
    {
        // 1. Check karein ke Role Name khali to nahi
        if (string.IsNullOrWhiteSpace(model.Role.RoleName))
        {
            ModelState.AddModelError("Role.RoleName", "Role name is required.");
            model.Roles = await _roleService.GetAllRolesAsync(); // List refresh karna zaroori hai
            return View("Index", model);
        }

        // 2. DTO se IdentityRole object banayein
        var roleToUpdate = new IdentityRole
        {
            Id = model.Role.Id, // Hidden field wali ID yahan aayegi
            Name = model.Role.RoleName
        };

        // 3. Service call karein
        var success = await _roleService.UpdateRoleAsync(roleToUpdate);

        if (success)
        {
            TempData["Success"] = "Role updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        // 4. Agar fail ho jaye (e.g. Duplicate Name)
        ModelState.AddModelError("Role.RoleName", "Failed to update. Possible duplicate name.");
        model.Roles = await _roleService.GetAllRolesAsync();
        return View("Index", model);
    }


}