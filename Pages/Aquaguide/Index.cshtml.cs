using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AquaGuide.Data;
using Microsoft.AspNetCore.Authorization;
using AquaGuide.Entities;

namespace AquaGuide2.Pages.Database
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AquaGuide.Data.ApplicationDbContext _context;

        public IndexModel(AquaGuide.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Parameter> Parameter { get;set; }

        public async Task OnGetAsync()
        {
            Parameter = await _context.Parameters.ToListAsync();
        }
    }
}
