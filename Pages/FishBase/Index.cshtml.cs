﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AquaGuide.Data;
using AquaGuide.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AquaGuide2.Pages.FishBase
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private string UserId { get; set; }
        private readonly AquaGuide.Data.ApplicationDbContext _context;

        public IndexModel(AquaGuide.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Fish> Fish { get;set; }

        public async Task OnGetAsync()
        {
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Fish = await _context.Fishes.Where(p => p.UserId == UserId).ToListAsync();
        }
    }
}
