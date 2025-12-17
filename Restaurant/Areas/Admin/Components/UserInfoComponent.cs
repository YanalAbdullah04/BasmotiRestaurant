using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.ViewModels;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Components
{
    [Area ("Admin")]
    public class UserInfoComponent :ViewComponent
    {

        public UserInfoComponent( UserManager<AdminUser> usermanager)
        {
            Usermanager = usermanager;
        }

        public UserManager<AdminUser> Usermanager { get; }

        public async Task<IViewComponentResult> InvokeAsync()

        {
            var result = await Usermanager.GetUserAsync((ClaimsPrincipal)User);


            AdminUserModel adminUserModel = new()
            {
                FullName = result.FullName,
                imageurl = result.imageurl
            };





            return View(adminUserModel);
        }
    }
}
