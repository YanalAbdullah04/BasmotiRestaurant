using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> Repository { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenuRepository { get; }
        public IHostingEnvironment Host { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu>repository,IRepository<MasterCategoryMenu> MasterCategoryMenuRepository,IHostingEnvironment host )
        {
            Repository = repository;
            this.MasterCategoryMenuRepository = MasterCategoryMenuRepository;
            Host = host;
        }
        // GET: MasterItemMenuController
        public ActionResult Index()
        {

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogIn", "Account");
            var data = Repository.View();
            return View(data);
        }


        // GET: MasterItemMenuController/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogIn", "Account");
            ViewBag.ListMasterCategoryMenu = MasterCategoryMenuRepository.View();




            return View();
        }

        // POST: MasterItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ViewBag.ListMasterCategoryMenu = MasterCategoryMenuRepository.View();

               

                    return View();
                }
                
           
                collection.CreatUser = User.FindFirst(ClaimTypes.Name)?.Value;
              

                MasterItemMenu masterItemMenu = new()
                {
                    MasterItemMenuImageUrl =  SaveImage(collection.File),

                    CreatDate = collection.CreatDate,
                    CreatUser = User.FindFirst(ClaimTypes.Name)?.Value,
                    EditDate = collection.EditDate,
                    EditUser=collection.EditUser,
                    IsActive = collection.IsActive, 
                    MasterCategoryMenu = collection.MasterCategoryMenu,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuId = collection.MasterItemMenuId,
                 
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,



                };





                Repository.Add(masterItemMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
               return RedirectToAction("LogIn","Account");
            }

            ViewBag.ListMasterCategoryMenu = MasterCategoryMenuRepository.View();
            var data = Repository.Find(id);

            MasterItemMenuModel masteritemmodel = new()
            {
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterItemMenuPrice = data.MasterItemMenuPrice,
                MasterItemMenuTitle = data.MasterItemMenuTitle,
                MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                MasterItemMenuId = data.MasterItemMenuId,
                CreatDate = data.CreatDate,
                EditDate = data.EditDate,
                CreatUser = data.CreatUser,
                EditUser = data.EditUser,
                MasterCategoryMenu = data.MasterCategoryMenu,
                MasterItemMenuBreef = data.MasterItemMenuBreef,
                MasterItemMenuDate = data.MasterItemMenuDate,
                MasterItemMenuDesc = data.MasterItemMenuDesc,



            };



            return View(masteritemmodel);
        }

        // POST: MasterItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuModel collection)
        {
            try
            {
                ViewBag.ListMasterCategoryMenu = MasterCategoryMenuRepository.View();
                collection.EditUser = User.FindFirst(ClaimTypes.Name)?.Value;

                string imagename = SaveImage(collection.File);

           imagename= imagename==""?collection.MasterItemMenuImageUrl:imagename;


                MasterItemMenu masterItemMenu = new()
                {

                    MasterItemMenuImageUrl = imagename,


                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,

                    MasterItemMenuId = collection.MasterItemMenuId,
                    CreatDate = collection.CreatDate,
                    EditDate = collection.EditDate,
                    CreatUser = collection.CreatUser,
                    EditUser = collection.EditUser,
                    MasterCategoryMenu = collection.MasterCategoryMenu,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    



                };

                Repository.Update(id,masterItemMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // POST: MasterItemMenuController/Delete/5

        public ActionResult Delete(int deleteid)
        {
            var allowed = Repository.View().Where(x => x.IsDeleted == false && x.MasterItemMenuId != deleteid && x.IsActive && x.MasterItemMenuId != deleteid).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Delete(deleteid, null);

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Active(int id)
        {

            var allowed = Repository.View().Where(x => x.IsActive && x.MasterItemMenuId != id).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Active(id);


            return RedirectToAction(nameof(Index));
        }



        private string SaveImage (IFormFile file)
        {
            string imagename = "";
            if (file != null)
            {
                
                string rootpath = Path.Combine(Host.WebRootPath,"images");
                FileInfo f1=new FileInfo(file.FileName);
                imagename= "Image"+Guid.NewGuid().ToString()+f1.Extension ;
                string fullpath=Path.Combine(rootpath,imagename);
                file.CopyTo(new FileStream(fullpath, FileMode.Create));


            }
            return imagename;


        }



        
    }
}
