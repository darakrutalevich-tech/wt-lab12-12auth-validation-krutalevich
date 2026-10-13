using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab12_12auth_validation_krutalevich.Data;

namespace wt_lab12_12auth_validation_krutalevich.Pages;

public class LoginModel : PageModel
{
    private readonly AppDbContext _context;

    public LoginModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    [Required(ErrorMessage = "Введите логин")]
    [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Логин должен содержать от 3 до 50 символов")]
    public string Login { get; set; } = "";

    [BindProperty]
    [Required(ErrorMessage = "Введите пароль")]
    [StringLength(100, MinimumLength = 4,
        ErrorMessage = "Пароль должен содержать не менее 4 символов")]
    public string Password { get; set; } = "";

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Login == Login && x.Password == Password);

        if (user == null)
        {
            ModelState.AddModelError("", "Неверный логин или пароль.");
            return Page();
        }

        HttpContext.Session.SetString("UserLogin", user.Login);

        return RedirectToPage("/Flights/Index");
    }
}