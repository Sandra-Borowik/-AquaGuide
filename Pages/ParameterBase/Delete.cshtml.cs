using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AquaGuide.Data;
using AquaGuide.Entities;

namespace AquaGuide2.Pages.ParameterBase
{
    public class DeleteModel : PageModel
    {
        private readonly AquaGuide.Data.ApplicationDbContext _context;

        public DeleteModel(AquaGuide.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parameter Parameter { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parameter = await _context.Parameters.FirstOrDefaultAsync(m => m.ID == id);

            if (Parameter == null)
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

            Parameter = await _context.Parameters.FindAsync(id);

            if (Parameter != null)
            {
                _context.Parameters.Remove(Parameter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
