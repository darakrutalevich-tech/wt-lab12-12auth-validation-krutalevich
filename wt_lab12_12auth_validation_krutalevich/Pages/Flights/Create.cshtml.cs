using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using wt_lab12_12auth_validation_krutalevich.Data;
using wt_lab12_12auth_validation_krutalevich.Models;

namespace wt_lab12_12auth_validation_krutalevich.Pages.Flights;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Flight Flight { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Flights.Add(Flight);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}