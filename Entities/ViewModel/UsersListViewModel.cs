using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaGuide2.Entities.ViewModel
{
    public class UsersListViewModel
    {
        public List<ApplicationUser> ApplicationUserList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
