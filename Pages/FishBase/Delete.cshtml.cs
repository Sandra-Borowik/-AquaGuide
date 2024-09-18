using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AquaGuide.Data;
using AquaGuide.Entities;

namespace AquaGuide2.Pages.FishBase
{
    public class DeleteModel : PageModel
    {
        private readonly AquaGuide.Data.ApplicationDbContext _context;

        public DeleteModel(AquaGuide.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fish Fish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fish = await _context.Fishes.FirstOrDefaultAsync(m => m.ID == id);

            if (Fish == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fish = await _context.Fishes.FindAsync(id);

            if (Fish != null)
            {
                _context.Fishes.Remove(Fish);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
