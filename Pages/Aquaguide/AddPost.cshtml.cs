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
    public class AddPostModel : PageModel
    {
        private readonly ApplicationDbContext _database;

        public AddPostModel(ApplicationDbContext database)
        {
            _database = database;
        }

        [BindProperty]
        public Post Post { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Post Post)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Post.Date = DateTime.Now;

            _database.Posts.Add(Post);
            await _database.SaveChangesAsync();

            return Page();
        }
    }
}