using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AquaGuide.Data;
using AquaGuide.Entities;

namespace AquaGuide2.Pages.Database
{
    public class DetailsModel : PageModel
    {
        private readonly AquaGuide.Data.ApplicationDbContext _context;

        public DetailsModel(AquaGuide.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
