﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AquaGuide.Data;
using AquaGuide.Entities;

namespace AquaGuide2.Pages.Database
{
    public class EditModel : PageModel
    {
        private readonly AquaGuide.Data.ApplicationDbContext _context;

        public EditModel(AquaGuide.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Parameter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParameterExists(Parameter.ID))
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

        private bool ParameterExists(int id)
        {
            return _context.Parameters.Any(e => e.ID == id);
        }
    }
}
