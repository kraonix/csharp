using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Services;

[Route("auth")]
public class AuthController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtService _jwtService;
    private readonly AppDbContext _context;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        JwtService jwtService,
        AppDbContext context)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _context = context;
    }

    // 🔥 LOGIN PAGE
    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    // 🔥 LOGIN LOGIC
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.FindByNameAsync(model.Username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        var roles = await _userManager.GetRolesAsync(user);

        // 🔥 FIRST LOGIN CHECK
        if (user.IsFirstLogin)
        {
            // store temp user id in session (or cookie)
            HttpContext.Session.SetString("UserId", user.Id);
            return RedirectToAction("ChangePassword");
        }

        var token = _jwtService.GenerateToken(user, roles);

        Response.Cookies.Append("jwt", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Strict
        });

        var role = roles.FirstOrDefault();

        return role switch
        {
            "Admin" => RedirectToAction("Dashboard", "Admin"),
            "Faculty" => RedirectToAction("Dashboard", "Faculty"),
            "Student" => RedirectToAction("Dashboard", "Student"),
            _ => RedirectToAction("Login")
        };
    }

    // 🔥 REGISTER PAGE
    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }

    // 🔥 REGISTER REQUEST
    [HttpPost("register")]
    public IActionResult Register(UserRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        request.IsApproved = false;

        _context.UserRequests.Add(request);
        _context.SaveChanges();

        return Content("✅ Request submitted! Wait for admin approval.");
    }

    // 🔥 CHANGE PASSWORD PAGE
    [HttpGet("changepassword")]
    public IActionResult ChangePassword()
    {
        return View();
    }

    // 🔥 CHANGE PASSWORD LOGIC
    [HttpPost("changepassword")]
    public async Task<IActionResult> ChangePassword(string newPassword)
    {
        var userId = HttpContext.Session.GetString("UserId");

        if (userId == null)
            return RedirectToAction("Login");

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return RedirectToAction("Login");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

        if (!result.Succeeded)
            return Content("Password change failed");

        user.IsFirstLogin = false;
        await _userManager.UpdateAsync(user);

        return RedirectToAction("Login");
    }

    // 🔥 LOGOUT
    [Authorize]
    [HttpGet("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        HttpContext.Session.Clear();

        return RedirectToAction("Login");
    }
}