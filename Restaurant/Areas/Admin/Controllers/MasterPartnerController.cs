using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Collections;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> Repository { get; }
        public IHostingEnvironment Host { get; }

        public MasterPartnerController(IRepository<MasterPartner>repository,IHostingEnvironment host )
        {
            Repository = repository;
            Host = host;
        }
        // GET: MasterPartnerController
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");   
            }
            var data = Repository.View();
            return View(data);
        }

 

        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }

            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "model state error ");
                    return View();
                }
                if (collection.File == null)
                {
                    ModelState.AddModelError("", "enter image");
                    return View();


                }
                MasterPartner masterPartner = new()
                {
                    CreatDate = DateTime.Now,
                    EditDate = DateTime.Now,
                    CreatUser = User.FindFirst(ClaimTypes.Name)?.Value,
                    IsActive = true,
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerLogoImageUrl = SaveImage(collection.File),
                    EditUser=collection.EditUser,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    
                };

                Repository.Add(masterPartner);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }
            var data = Repository.Find(id);


            MasterPartnerModel masterPartnermodel = new()
            {
                CreatDate = data.CreatDate,
                EditDate = data.EditDate,
                CreatUser =data.CreatUser,
              IsActive=data.IsActive,
              MasterPartnerLogoImageUrl=data.MasterPartnerLogoImageUrl,
             
                MasterPartnerId = data.MasterPartnerId,
              
                EditUser = data.EditUser,
                MasterPartnerName = data.MasterPartnerName,
                MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,

            };

            return View(masterPartnermodel);
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "model state error ");
                    return View();
                }

                string imagname = SaveImage(collection.File);
                imagname=imagname==""?collection.MasterPartnerLogoImageUrl:imagname;


                MasterPartner masterPartner = new()
                {
                    CreatDate = collection.CreatDate,

                    CreatUser = collection.CreatUser,
                    IsActive = collection.IsActive,
                    MasterPartnerLogoImageUrl = imagname,

                    MasterPartnerId = collection.MasterPartnerId,

                    EditUser = User.FindFirst(ClaimTypes.Name)?.Value,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    EditDate = DateAndTime.Now

                };
                Repository.Update(id, masterPartner);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Delete/5
        public ActionResult Delete(int deleteid)
        {
            var allowed = Repository.View().Where(x => x.IsDeleted == false && x.MasterPartnerId != deleteid && x.IsActive && x.MasterPartnerId != deleteid).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Delete(deleteid, null);

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Active(int id)
        {

            var allowed = Repository.View().Where(x => x.IsActive && x.MasterPartnerId != id).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Active(id);


            return RedirectToAction(nameof(Index));
        }



        private string SaveImage(IFormFile file)
        {
            string imagename = "";
            if (file != null)
            {

                string rootpath = Path.Combine(Host.WebRootPath, "images");
                FileInfo f1 = new FileInfo(file.FileName);
                imagename = "Image" + Guid.NewGuid().ToString() + f1.Extension;
                string fullpath = Path.Combine(rootpath, imagename);
                file.CopyTo(new FileStream(fullpath, FileMode.Create));


            }
            return imagename;


        }
    }
}
