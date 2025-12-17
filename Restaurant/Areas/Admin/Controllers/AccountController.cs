using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using NuGet.Protocol.Core.Types;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class AccountController : Controller
    {
        public UserManager<AdminUser> UserManager { get; }
        public SignInManager<AdminUser> SignInManager { get; }
        public IHostingEnvironment Host { get; }
        public IOptions<IdentityOptions> IdentityOptions { get; }

        public AccountController( UserManager< AdminUser>userManager,
            SignInManager<AdminUser>signInManager,
            IHostingEnvironment host
            )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Host = host;
        }



        // GET: AccountController
        public ActionResult LogIn()
        {


            return View();
        }

        public ActionResult Register()
        {

            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(LogIn));
            }
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register (Register collection)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "An error has acured");
                    return View();
                    
                }
                //if(string.IsNullOrEmpty(collection.UserName))
                //{
                //    collection.UserName = collection.Email;
                //}
                var user = new AdminUser()
                {
                    Email = collection.Email,
                    UserName = collection.Email,
                    imageurl= "Unknown_person.jpg"


                };

                var result = await UserManager.CreateAsync(user, collection.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(LogIn));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                

                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5


        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(LogIn collection)
        {
            try
            {
               if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "an error has acured");
                    return View();
                }
                var result = await SignInManager.PasswordSignInAsync(collection.Email,  
                    collection.Password,isPersistent:collection.RemmberMe,false);

                if (result.Succeeded)
                {
                     return RedirectToAction("Index", "MasterServices");
                }
                else
                {
           
                }
                    return View();
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIn));
        }

        public async Task<ActionResult> Profile()
        {




            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(LogIn));
            }
            var user = await UserManager.GetUserAsync(User);
            AdminUserModel adminUserModel = new()
            {
                Email = user.Email,
                imageurl = user.imageurl,
                JobTitle = user.JobTitle,
                Address = user.Address,
                BirthDate = user.BirthDate,
                Country = user.Country,
                FullName = user.FullName,
                phoneNumber=user.PhoneNumber,
                FaceBookLink = user.FaceBookLink,
               InstegramLink = user.InstegramLink,
               LinkedInLink = user.LinkedInLink,
               TwitterLink = user.TwitterLink   ,
              
                
               
            };


            return View(adminUserModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(AdminUserModel collection)
        {


            try
            {


                var user = await UserManager.GetUserAsync(User);


                string imagename = SaveImage(collection.ImageFile);

                imagename = imagename == "" ? collection.imageurl : imagename;
                user.JobTitle = collection.JobTitle;
                user.Address = collection.Address;
                user.imageurl = imagename;
                user.InstegramLink = collection.InstegramLink;
                user.Address = collection.Address;
                user.BirthDate = collection.BirthDate;
                user.Country = collection.Country;
                user.FullName = collection.FullName;
                user.Address=collection.Address;
                user.PhoneNumber=collection.phoneNumber;
                user.Email = collection.Email;
                user.TwitterLink = collection.TwitterLink;
                user.LinkedInLink = collection.LinkedInLink;
                user.FaceBookLink = collection.FaceBookLink;
                user.FullName=collection.FullName;


                var updateResult = await UserManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    ModelState.AddModelError("", "!success");
                }

                return RedirectToAction(nameof(Profile));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete()
        {

          var user=await UserManager.GetUserAsync(User);
            user.imageurl = "Unknown_person.jpg";
          var result=await UserManager.UpdateAsync(user);

            return RedirectToAction(nameof(Profile));
        }

        private string SaveImage(IFormFile file)
        {
            string imagename = "";
            if (file != null)
            {

                string rootpath = Path.Combine(Host.WebRootPath,"Admin","assets","img");
                FileInfo f1 = new FileInfo(file.FileName);
                imagename = "Image" + Guid.NewGuid().ToString() + f1.Extension;
                string fullpath = Path.Combine(rootpath, imagename);
                file.CopyTo(new FileStream(fullpath, FileMode.Create));
            }
            return imagename;
        }
    }
}

