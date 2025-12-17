using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> Repository { get; }
        public IHostingEnvironment Host { get; }

        public MasterOfferController(IRepository<MasterOffer>repository,IHostingEnvironment host)
        {
            Repository = repository;
            Host = host;
        }
        // GET: MasterOfferController
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }

            var data = Repository.View();
            return View(data);
        }

        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }



            return View();
        }

        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferModel collection)
        {
            try
            {
                if (!ModelState.IsValid) {

                    ModelState.AddModelError("", "model Error");

                    return View();
                }
                if (collection.File == null) {
                    ModelState.AddModelError("", "the photo is required");
                    return View();

                }
                string imagname = saveimage(collection.File);

                MasterOffer master = new()
                {
                    CreatDate = DateTime.Now,
                    CreatUser = User.FindFirst(ClaimTypes.Name)?.Value,
                    EditDate = DateTime.Now,
                    IsDeleted = false,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferImageUrl = imagname,
                    MasterOfferTitle = collection.MasterOfferTitle



                };

                Repository.Add(master);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }

            var data = Repository.Find(id);

            MasterOfferModel masterofermodel = new()
            {MasterOfferTitle=data.MasterOfferTitle,
            MasterOfferBreef=data.MasterOfferBreef,
            MasterOfferDesc=data.MasterOfferDesc,
            MasterOfferId=data.MasterOfferId,
            MasterOfferImageUrl=data.MasterOfferImageUrl,
            CreatDate=DateTime.Now,
            CreatUser=data.CreatUser,
            EditDate=DateTime.Now,
            IsActive=data.IsActive,
           
           
       
            

            };

            return View(masterofermodel);
        }

        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferModel collection)
        {
            try
            {
                if (!ModelState.IsValid) {

                    ModelState.AddModelError("", "error model");

                    return View();
                }

                string imgurl = saveimage (collection.File);
                imgurl=imgurl==""?collection.MasterOfferImageUrl:imgurl;
                MasterOffer masterOffer = new()
                {
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferImageUrl = imgurl,
                    CreatDate = collection.CreatDate,
                    CreatUser = collection.CreatUser,
                    EditDate = DateTime.Now,
                    EditUser = User.FindFirst(ClaimTypes.Name)?.Value,
                   IsActive = collection.IsActive,
                   MasterOfferBreef=collection.MasterOfferBreef,
                   MasterOfferDesc=collection.MasterOfferDesc,
                   MasterOfferId=collection.MasterOfferId,  

                };

                Repository.Update(id, masterOffer );
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Delete/5
        public ActionResult Delete(int deleteid)
        {
            var allowed = Repository.View().Where(x => x.IsDeleted == false && x.MasterOfferId != deleteid && x.IsActive && x.MasterOfferId != deleteid).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Delete(deleteid, null);

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Active(int id)
        {

            var allowed = Repository.View().Where(x => x.IsActive && x.MasterOfferId != id).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Active(id);


            return RedirectToAction(nameof(Index));
        }




        private string saveimage(IFormFile file)
        {

            string imagename = "";
            if (file != null) {

                string imagepath = Path.Combine(Host.WebRootPath, "images");
                FileInfo f = new FileInfo(file.FileName);
                imagename = "Images" + Guid.NewGuid().ToString() + f.Extension;
                string fullpathwithname = Path.Combine(imagepath,imagename);
                file.CopyTo(new FileStream(fullpathwithname,FileMode.Create));



            }

            return imagename;
        }
            
    }
}
