using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AquaGuide.Data;
using AquaGuide.Entities;

namespace AquaGuide2.Pages.Database
{
    public class CreateModel : PageModel
    {
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
        public Parameter Parameter { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Parameter.Date = DateTime.Now;
            _context.Parameters.Add(Parameter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
