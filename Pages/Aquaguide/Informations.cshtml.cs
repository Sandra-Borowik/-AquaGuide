using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaGuide.Pages
{
    public class InformationsModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}