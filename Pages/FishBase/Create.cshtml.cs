using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AquaGuide.Data;
using Microsoft.AspNetCore.Authorization;
using AquaGuide.Entities;

namespace AquaGuide2.Pages.FishBase
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private string UserId { get; set; }
        private readonly AquaGuide.Data.ApplicationDbContext _context;

        public CreateModel(AquaGuide.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fish Fish { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Fish.UserId = UserId;
            _context.Fishes.Add(Fish);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
