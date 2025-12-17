using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterSocialMediaController : Controller
    {
        public IRepository<MasterSocialMedia> Repository { get; }
        public IHostingEnvironment Host { get; }

        public MasterSocialMediaController(IRepository<MasterSocialMedia>repository,IHostingEnvironment host)
        {
            Repository = repository;
            Host = host;
        }
        // GET: MasterSocialMediaController
        public ActionResult Index()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }
            var data = Repository.View();

            return View(data);
        }


        // GET: MasterSocialMediaController/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }
            return View();
        }

        // POST: MasterSocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( MasterSocialMediaModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Modelstate error ");
                    return View();

                }
                if (collection.File == null) {
                    ModelState.AddModelError("", "insert photo ");
                    return View();
                }

                collection.CreatUser = User.FindFirst(ClaimTypes.Name)?.Value;
                collection.MasterSocialMediaImageUrl = SaveImage(collection.File);
                MasterSocialMedia masterSocialMedia = new MasterSocialMedia
                {
                    CreatUser = collection.CreatUser,
                    CreatDate = collection.CreatDate,
                    EditDate = collection.EditDate,
                    EditUser = collection.EditUser,
                    MasterSocialMediaId = collection.MasterSocialMediaId,
                    IsActive = collection.IsActive,

                    MasterSocialMediaImageUrl = collection.MasterSocialMediaImageUrl,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,


                };
                Repository.Add(masterSocialMedia);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }
            var data = Repository.Find(id);
            MasterSocialMediaModel masterSocialMediaModel = new()
            {
                CreatUser = data.CreatUser,
                EditDate = data.EditDate,
                EditUser = data.EditUser,
                CreatDate = data.CreatDate,
                IsDeleted = data.IsDeleted,
                MasterSocialMediaId = data.MasterSocialMediaId,
                IsActive = data.IsActive,
                MasterSocialMediaImageUrl = data.MasterSocialMediaImageUrl,
                MasterSocialMediaUrl = data.MasterSocialMediaUrl,


            };




            return View(masterSocialMediaModel);
        }

        // POST: MasterSocialMediaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediaModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Modelstate error ");
                    return View();

                }
                collection.EditUser = User.FindFirst(ClaimTypes.Name)?.Value;
                string imagname = SaveImage(collection.File);
                collection.MasterSocialMediaImageUrl=imagname==""?collection.MasterSocialMediaImageUrl:imagname;

                MasterSocialMedia masterSocial = new()
                {
                    CreatDate = collection.CreatDate,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
                    CreatUser = collection.CreatUser,
                    MasterSocialMediaId = collection.MasterSocialMediaId,
                    IsActive = collection.IsActive,
                    EditUser = collection.EditUser,
                    EditDate = collection.EditDate,
                    MasterSocialMediaImageUrl = collection.MasterSocialMediaImageUrl



                };
                Repository.Update(id, masterSocial);

                



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Delete/5
        public ActionResult Delete(int deleteid)
        {
            var allowed = Repository.View().Where(x => x.IsDeleted == false && x.MasterSocialMediaId != deleteid && x.IsActive && x.MasterSocialMediaId != deleteid).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Delete(deleteid, null);

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Active(int id)
        {

            var allowed = Repository.View().Where(x => x.IsActive && x.MasterSocialMediaId != id).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Active(id);


            return RedirectToAction(nameof(Index));
        }

        private string SaveImage(IFormFile file)
        {
            string imagname = "";
            if (file != null)
            {
                string imagpath = Path.Combine(Host.WebRootPath, "images");
                FileInfo f = new(file.FileName);
                imagname = "Images" + Guid.NewGuid().ToString() + f.Extension;
                string fullpath = Path.Combine(imagpath, imagname);
                file.CopyTo(new FileStream(fullpath, FileMode.Create));

            }
            return imagname;
        }
    }
}
