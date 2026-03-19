using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Data;

namespace UniversityManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // 🔥 DASHBOARD
        public async Task<IActionResult> Dashboard()
        {
            var totalUsers = _userManager.Users.Count();
            var totalAdmins = (await _userManager.GetUsersInRoleAsync("Admin")).Count;
            var totalFaculty = (await _userManager.GetUsersInRoleAsync("Faculty")).Count;
            var totalStudents = (await _userManager.GetUsersInRoleAsync("Student")).Count;

            ViewBag.TotalUsers = totalUsers;
            ViewBag.Admins = totalAdmins;
            ViewBag.Faculty = totalFaculty;
            ViewBag.Students = totalStudents;

            return View();
        }

        // 🔥 ALL USERS
        public IActionResult Users()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // 🔥 PENDING REQUESTS ONLY
        public IActionResult Requests()
        {
            var requests = _context.UserRequests
                .Where(r => !r.IsApproved)
                .ToList();

            return View(requests);
        }

        // 🔥 APPROVE REQUEST (CORE FEATURE)
        public async Task<IActionResult> Approve(int id)
        {
            var req = _context.UserRequests.Find(id);

            if (req == null)
                return NotFound();

            var user = new ApplicationUser
            {
                UserName = req.Email,
                Email = req.Email,
                FullName = req.FullName,
                IsFirstLogin = true
            };

            var result = await _userManager.CreateAsync(user, "First@123");

            if (!result.Succeeded)
                return Content("User creation failed");

            // ensure role exists
            if (!await _roleManager.RoleExistsAsync(req.Role))
                await _roleManager.CreateAsync(new IdentityRole(req.Role));

            await _userManager.AddToRoleAsync(user, req.Role);

            // mark as approved instead of deleting (better practice)
            req.IsApproved = true;
            _context.SaveChanges();

            return RedirectToAction("Requests");
        }

        // ❌ REJECT REQUEST
        public IActionResult Reject(int id)
        {
            var req = _context.UserRequests.Find(id);

            if (req != null)
            {
                _context.UserRequests.Remove(req);
                _context.SaveChanges();
            }

            return RedirectToAction("Requests");
        }

        // 🔥 ASSIGN ROLE
        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            await _userManager.AddToRoleAsync(user, role);

            return RedirectToAction("Users");
        }

        // 🗑 DELETE USER
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
                await _userManager.DeleteAsync(user);

            return RedirectToAction("Users");
        }
    }
}