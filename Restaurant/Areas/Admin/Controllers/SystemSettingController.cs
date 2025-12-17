using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> Repository { get; }
        public IHostingEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting>repository,IHostingEnvironment Host)
        {
            Repository = repository;
            this.Host = Host;
        }
        // GET: SystemSettingController
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn","Account");
            }

            var data = Repository.View();

            return View(data);
        }

        // GET: SystemSettingController/Details/5


        // GET: SystemSettingController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: SystemSettingController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }
            var data = Repository.Find(id);
            SystemSettingModel systemSettingModel = new()
            {
                ContactUsEmail = data.ContactUsEmail,
                ContactUsLocation = data.ContactUsLocation,
                ContactUsPhone = data.ContactUsPhone,
                SystemSettingCopyright = data.SystemSettingCopyright,
                SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                SystemSettingMapLocation = data.SystemSettingMapLocation,
                SystemSettingId = data.SystemSettingId,
                SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                EditUser = data.EditUser,  
                EditDate = data.EditDate,
                IsActive = data.IsActive,





            };


            return View(systemSettingModel);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "MODEL state error ");
                    return View();

                }



                collection.EditUser = User.FindFirst(ClaimTypes.Name)?.Value;

                collection.SystemSettingLogoImageUrl = SaveImage(collection.SystemSettingLogoImageUrl, collection.LogoFile1);
                collection.SystemSettingLogoImageUrl2 = SaveImage(collection.SystemSettingLogoImageUrl2, collection.LogoFile2);
                collection.SystemSettingWelcomeNoteImageUrl = SaveImage(collection.SystemSettingWelcomeNoteImageUrl, collection.WelcomFile);
         
          
                SystemSetting systemSetting = new SystemSetting()
                {
                    ContactUsEmail = collection.ContactUsEmail, 
                    ContactUsPhone = collection.ContactUsPhone,
                    ContactUsLocation = collection.ContactUsLocation,

                    EditDate = collection.EditDate,
                    EditUser = collection.EditUser,
                    IsDeleted = collection.IsDeleted,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingId = collection.SystemSettingId,
                   SystemSettingLogoImageUrl = collection.SystemSettingLogoImageUrl,
                   SystemSettingWelcomeNoteImageUrl = collection.SystemSettingWelcomeNoteImageUrl,
                   SystemSettingLogoImageUrl2 = collection.SystemSettingLogoImageUrl2,
                   SystemSettingMapLocation = collection.SystemSettingMapLocation,
                   SystemSettingWelcomeNoteBreef=collection.SystemSettingWelcomeNoteBreef,
                   SystemSettingWelcomeNoteDesc=collection.SystemSettingWelcomeNoteDesc,
                   SystemSettingWelcomeNoteTitle=collection.SystemSettingWelcomeNoteTitle,
                   SystemSettingWelcomeNoteUrl=collection.SystemSettingWelcomeNoteUrl,
                   
                   
                   
                };

                Repository.Update(id, systemSetting);



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5
   

        private string  SaveImage(string imageurl,IFormFile File)
        {

            string imagename=null;

            if (File != null)
            {

                string Imagepath = Path.Combine(Host.WebRootPath, "images");
                FileInfo f = new FileInfo(File.FileName);
                imagename = "images" + Guid.NewGuid().ToString() + f.Extension;
                string fullpath = Path.Combine(Imagepath, imagename);
                File.CopyTo(new FileStream(fullpath, FileMode.Create));

            }
            if (string.IsNullOrEmpty(imagename))
            {
                imagename = imageurl;
            }
             return imagename;                
            }
           

        }
    }

