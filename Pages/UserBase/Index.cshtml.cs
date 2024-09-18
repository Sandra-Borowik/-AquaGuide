using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaGuide.Data;
using AquaGuide2.Entities;
using AquaGuide2.Entities.ViewModel;
using AquaGuide2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AquaGuide2.Pages.UserBase
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _database;

        public IndexModel(ApplicationDbContext database)
        {
            _database = database;
        }

        [BindProperty]
        public UsersListViewModel UsersListVM { get; set; }

        public async Task<IActionResult> OnGet(int productPage = 1, string searchID = null, string searchNickname = null, string searchEmail = null)
        {
            UsersListVM = new UsersListViewModel()
            {
                ApplicationUserList = await _database.ApplicationUser.ToListAsync()
        };

            StringBuilder param = new StringBuilder();
            param.Append("/UserBase?productPage=:");
            param.Append("&searchID=");
            if(searchID != null)
            {
                param.Append(searchID);
            }
            param.Append("&searchNickname=");
            if (searchNickname != null)
            {
                param.Append(searchNickname);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }

            if (searchEmail != null)
            {
                UsersListVM.ApplicationUserList = await _database.ApplicationUser.Where(u => u.Email.ToLower().Contains(searchEmail.ToLower())).ToListAsync();
            }
            else
            {

                if (searchID != null)
                {
                    UsersListVM.ApplicationUserList = await _database.ApplicationUser.Where(u => u.Id.ToLower().Contains(searchID.ToLower())).ToListAsync();
                }
                else
                {
                    if (searchNickname != null)
                    {
                        UsersListVM.ApplicationUserList = await _database.ApplicationUser.Where(u => u.Nickname.ToLower().Contains(searchNickname.ToLower())).ToListAsync();
                    }
                }
            }

            var count = UsersListVM.ApplicationUserList.Count;

            UsersListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                IteamsPerPage = SD.PaginationUsersPage,
                TotalIteams = count,
                UrlParam = param.ToString()
            };

            UsersListVM.ApplicationUserList = UsersListVM.ApplicationUserList.OrderBy(p => p.Email)
                .Skip((productPage - 1) * SD.PaginationUsersPage)
                .Take(SD.PaginationUsersPage).ToList();
            return Page();
        }
    }
}
