using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquaGuide.Data;
using AquaGuide.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AquaGuide.Pages.Database
{
    public class AddCommentModel : PageModel
    {
        private readonly ApplicationDbContext _database;

        public AddCommentModel(ApplicationDbContext database)
        {
            _database = database;
        }

        [BindProperty]
        public Comment Comment { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Comment Comment)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Comment.Date = DateTime.Now;

            _database.Comments.Add(Comment);
            await _database.SaveChangesAsync();

            return Page();
        }
    }
}