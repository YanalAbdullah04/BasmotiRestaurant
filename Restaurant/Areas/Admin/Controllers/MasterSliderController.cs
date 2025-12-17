using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Drawing;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> Repository { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        // GET: MasterSliderController
        public MasterSliderController(IRepository<MasterSlider>repository,IHostingEnvironment host)
        {
            Repository = repository;
            Host = host;
        }
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }
            var data = Repository.View();
            return View(data);
        }


        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }

            return View();
        }

        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderModel collection)
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
                    ModelState.AddModelError("","pleas insert image");
                    return View();
                }
                collection.CreatUser = User.FindFirst(ClaimTypes.Name)?.Value;
                collection.MasterSliderImageUrl = SaveImage(collection.File);
                MasterSlider master = new()
                {
                   CreatUser=collection.CreatUser,
                   IsActive=true,
                   MasterSliderBreef=collection.MasterSliderBreef,
                   MasterSliderDesc=collection.MasterSliderDesc,
                   MasterSliderId=collection.MasterSliderId,
                   MasterSliderImageUrl=collection.MasterSliderImageUrl,
                   MasterSliderTitle=collection.MasterSliderTitle,                                    
                };

                Repository.Add(master);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }
            var data = Repository.Find(id);
            MasterSliderModel masterSliderModel = new()
            {
                MasterSliderId = data.MasterSliderId,
                MasterSliderTitle = data.MasterSliderTitle,
                IsActive = data.IsActive,
                CreatUser = data.CreatUser,
                EditUser = data.EditUser,
                CreatDate = data.CreatDate,
                EditDate = data.EditDate,
                MasterSliderImageUrl = data.MasterSliderImageUrl,
                MasterSliderBreef = data.MasterSliderBreef,
                MasterSliderDesc = data.MasterSliderDesc,
                
            };
            return View(masterSliderModel);
        }

        // POST: MasterSliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderModel collection)
        {
            try
            {
                if (! ModelState.IsValid)
                {

                    ModelState.AddModelError("", "model state error");
                    return View();
                }

                string imagname = SaveImage(collection.File);
                imagname = imagname == "" ? collection.MasterSliderImageUrl : imagname;
                collection.EditUser = User.FindFirst(ClaimTypes.Name)?.Value;


                MasterSlider masterSlider = new()
                {
                    CreatUser = collection.CreatUser,
                    IsActive = collection.IsActive,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderImageUrl = imagname,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    EditUser = collection.EditUser,
                    CreatDate = collection.CreatDate,
                    EditDate = DateTime.Now,


                };
                Repository.Update(id, masterSlider);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int deleteid)
        {
            var allowed = Repository.View().Where(x => x.IsDeleted == false && x.MasterSliderId != deleteid && x.IsActive && x.MasterSliderId != deleteid).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Delete(deleteid, null);

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Active(int id)
        {

            var allowed = Repository.View().Where(x => x.IsActive && x.MasterSliderId != id).ToList();
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
            if (file != null) {
                string imagpath = Path.Combine(Host.WebRootPath,"images");
                FileInfo f = new(file.FileName);
                imagname = "Images"+Guid.NewGuid().ToString()+f.Extension;
                string fullpath = Path.Combine(imagpath, imagname);
                file.CopyTo(new FileStream(fullpath, FileMode.Create));
            
            }
            return imagname;
        }
    }
}
