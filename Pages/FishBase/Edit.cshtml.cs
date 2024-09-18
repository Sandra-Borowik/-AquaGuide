using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AquaGuide.Data;
using AquaGuide.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AquaGuide2.Pages.FishBase
{
    [Authorize]
    public class EditModel : PageModel
    {
        private string UserId { get; set; }
        private readonly AquaGuide.Data.ApplicationDbContext _context;

        public EditModel(AquaGuide.Data.ApplicationDbContext context)
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

            _context.Attach(Fish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FishExists(Fish.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FishExists(int id)
        {
            return _context.Fishes.Any(e => e.ID == id);
        }
    }
}
