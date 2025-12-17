using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterServicesController : Controller

    {
        public IRepository<MasterServices> Repository { get; }
        public IHostingEnvironment Host { get; }

        public MasterServicesController(IRepository<MasterServices> repository, IHostingEnvironment host)
        {
            Repository = repository;
            Host = host;
        }
        // GET: MasterServicesController
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }
            var data = Repository.View();
            return View(data);
        }



        // GET: MasterServicesController/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }
            return View();
        }

        // POST: MasterServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServicesModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "model state error");
                    return View();
                }
                if (collection.File == null)
                {
                    ModelState.AddModelError("", "enter image");
                    return View();


                }
                collection.CreatUser = User.FindFirst(ClaimTypes.Name)?.Value;

                MasterServices masterServices = new()
                {
                    CreatUser = collection.CreatUser,

                    EditDate = collection.EditDate,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesId = collection.MasterServicesId,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesImage = SaveImage(collection.File),
                    IsActive = collection.IsActive,


                };
                Repository.Add(masterServices);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServicesController/Edit/5
        public ActionResult Edit(int id)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }
            var data = Repository.Find(id);
            MasterServicesModel masterServicesModel = new()
            {
                CreatDate = data.CreatDate,
                EditDate = data.EditDate,
                MasterServicesDesc = data.MasterServicesDesc,
                MasterServicesId = data.MasterServicesId,
                MasterServicesTitle = data.MasterServicesTitle,
                MasterServicesImage = data.MasterServicesImage,
                CreatUser = data.CreatUser,
                EditUser = data.EditUser,
                IsActive = data.IsActive,
               

            };




            return View(masterServicesModel);
        }

        // POST: MasterServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServicesModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "model state error");
                    return View();
                }

                string imagename = SaveImage(collection.File);
                imagename = imagename == "" ? collection.MasterServicesImage : imagename;
                collection.EditUser = User.FindFirst(ClaimTypes.Name)?.Value;

                MasterServices masterServices = new()
                {
                    CreatUser = collection.CreatUser,
                    EditUser = collection.EditUser,
                    EditDate = collection.EditDate,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesId = collection.MasterServicesId,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesImage = imagename,
                    CreatDate = collection.CreatDate,

                    IsActive = collection.IsActive,


                };
                Repository.Update(id, masterServices);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServicesController/Delete/5
        public ActionResult Delete(int deleteid)
        {
            var allowed = Repository.View().Where(x => x.IsDeleted == false && x.MasterServicesId != deleteid && x.IsActive && x.MasterServicesId != deleteid).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Delete(deleteid, null);

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Active(int id)
        {

            var allowed = Repository.View().Where(x => x.IsActive && x.MasterServicesId != id).ToList();
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
