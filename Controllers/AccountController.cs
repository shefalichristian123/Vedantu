using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vedantu.Data;
using Vedantu.Models;

namespace Vedantu.Controllers;

public class AccountController : Controller
{
    private readonly VedantuDbContext _db;

    public AccountController(VedantuDbContext db) => _db = db;

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var email = model.Email.Trim().ToLowerInvariant();
        if (await _db.Students.AnyAsync(s => s.Email == email))
        {
            ModelState.AddModelError(nameof(model.Email), "An account with this email already exists.");
            return View(model);
        }

        var student = new Student
        {
            FullName = model.FullName.Trim(),
            Email = email,
            Phone = model.Phone.Trim(),
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
        };

        _db.Students.Add(student);
        await _db.SaveChangesAsync();

        await SignIn(student);
        return RedirectToAction("Dashboard");
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid) return View(model);

        var email = model.Email.Trim().ToLowerInvariant();
        var student = await _db.Students.FirstOrDefaultAsync(s => s.Email == email);

        if (student == null || !BCrypt.Net.BCrypt.Verify(model.Password, student.PasswordHash))
        {
            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }

        await SignIn(student, model.RememberMe);

        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Dashboard");
    }

    [HttpGet]
    public IActionResult Dashboard()
    {
        if (!User.Identity?.IsAuthenticated ?? true)
            return RedirectToAction("Login");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("VedantuCookie");
        return RedirectToAction("Index", "Home");
    }

    private async Task SignIn(Student student, bool rememberMe = false)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, student.StudentId.ToString()),
            new(ClaimTypes.Name, student.FullName),
            new(ClaimTypes.Email, student.Email)
        };

        var identity = new ClaimsIdentity(claims, "VedantuCookie");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("VedantuCookie", principal,
            new AuthenticationProperties { IsPersistent = rememberMe });
    }
}
