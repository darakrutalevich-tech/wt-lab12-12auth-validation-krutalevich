using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab12_12auth_validation_krutalevich.Data;
using wt_lab12_12auth_validation_krutalevich.Models;

namespace wt_lab12_12auth_validation_krutalevich.Pages.Flights;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Flight? Flight { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);

        if (Flight == null)
            return NotFound();

        return Page();
    }
}