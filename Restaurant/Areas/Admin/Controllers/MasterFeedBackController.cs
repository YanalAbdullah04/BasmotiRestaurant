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
    public class MasterFeedBackController : Controller
    {
        public IRepository<MasterFeedBack> Repository { get; }
        public IHostingEnvironment Host { get; }

        public MasterFeedBackController(IRepository<MasterFeedBack>repository,IHostingEnvironment host )
        {
            Repository = repository;
            Host = host;
        }
        // GET: MasterFeedBackController
        public ActionResult Index()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn","Account");
            }
            var data = Repository.View();


            return View(data);
        }


        // GET: MasterFeedBackController/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }

            return View();
        }

        // POST: MasterFeedBackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterFeedBackModel collection)
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
                    ModelState.AddModelError("", "Image is required");
                }

                collection.CreatUser = User.FindFirst(ClaimTypes.Name)?.Value;
                collection.MasterFeedBackImageUrl=SaveImage(collection.File);

                MasterFeedBack masterFeedBack = new MasterFeedBack()
                {
                    CreatUser = collection.CreatUser,
                    MasterCustomerName = collection.MasterCustomerName,

                    MasterFeedBackCustomerBreef = collection.MasterFeedBackContent,
                    MasterFeedBackContent = collection.MasterFeedBackContent,
                    MasterFeedBackImageUrl = collection.MasterFeedBackImageUrl,
                    MasterFeedBackId = collection.MasterFeedBackId,

                };
                Repository.Add(masterFeedBack);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterFeedBackController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }

            var collection = Repository.Find(id);
            MasterFeedBackModel masterFeedBackmodel = new MasterFeedBackModel()
            {
                CreatDate = collection.CreatDate,
                CreatUser = collection.CreatUser,
                EditDate = collection.EditDate,
                EditUser = collection.EditUser,
                IsActive = collection.IsActive,
                MasterCustomerName = collection.MasterCustomerName,
                MasterFeedBackContent = collection.MasterFeedBackContent,
                MasterFeedBackCustomerBreef = collection.MasterFeedBackContent,
                MasterFeedBackId = collection.MasterFeedBackId,
                MasterFeedBackImageUrl = collection.MasterFeedBackImageUrl,
                IsDeleted = collection.IsDeleted,
            };

            return View(masterFeedBackmodel);
        }

        // POST: MasterFeedBackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterFeedBackModel collection)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "model state error");
                    return View();
                }

                string saveimage = SaveImage(collection.File);
                saveimage=saveimage==""?collection.MasterFeedBackImageUrl:saveimage;
                collection.MasterFeedBackImageUrl = saveimage;

                collection.EditUser = User.FindFirst(ClaimTypes.Name)?.Value;

                MasterFeedBack masterFeedBack = new()
                {
                    CreatDate = collection.CreatDate,
                    CreatUser = collection.CreatUser,
                    EditUser = collection.EditUser,
                    IsActive = collection.IsActive,
                    MasterCustomerName = collection.MasterCustomerName,
                    MasterFeedBackContent = collection.MasterFeedBackContent,
                    MasterFeedBackCustomerBreef = collection.MasterFeedBackCustomerBreef,
                    MasterFeedBackId = collection.MasterFeedBackId,
                    MasterFeedBackImageUrl = collection.MasterFeedBackImageUrl,
                };
                Repository.Update(id, masterFeedBack);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int deleteid)
        {
            var allowed = Repository.View().Where(x => x.IsDeleted == false && x.MasterFeedBackId != deleteid && x.IsActive && x.MasterFeedBackId != deleteid).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Delete(deleteid, null);

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Active(int id)
        {

            var allowed = Repository.View().Where(x => x.IsActive && x.MasterFeedBackId != id).ToList();
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
