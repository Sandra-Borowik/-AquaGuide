using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AquaGuide.Data;
using AquaGuide.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AquaGuide2.Pages.ParameterBase
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
        public Parameter Parameter { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Parameter.UserId = UserId;

            _context.Parameters.Add(Parameter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
