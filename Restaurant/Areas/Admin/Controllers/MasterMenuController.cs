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
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> Repository { get; }
        public IHostingEnvironment Host { get; }

        public MasterMenuController( IRepository<MasterMenu>repository,IHostingEnvironment host)
        {
            Repository = repository;
            Host = host;
        }
        public ActionResult Index()
        {

            if (!User.Identity.IsAuthenticated)
            {
                RedirectToAction("LogIn", "Account");
            }
            var data =Repository.View();
            return View(data);
        }


        // GET: MasterMenuController/Create
        public ActionResult Create()
        {



            
            return View();
        }

        // POST: MasterMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenuModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "model error");


                }

            
                MasterMenu masterMenu = new()
                {
                    CreatDate = DateTime.Now,
                    CreatUser = User.FindFirst(ClaimTypes.Name)?.Value,
                    MasterMenuUrl = collection.MasterMenuUrl,
                    MasterMenuId=collection.MasterMenuId,
                    MasterMenuName=collection.MasterMenuName,
              
                  




                };

                Repository.Add(masterMenu);
                


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {

            var data=Repository.Find(id);
            MasterMenuModel masterMenuModel = new()
            {
                MasterMenuName = data.MasterMenuName,
                MasterMenuId = data.MasterMenuId,
                CreatDate = DateTime.Now,
                CreatUser = data.CreatUser,
                EditDate = DateTime.Now,
                EditUser = data.EditUser,
                IsActive = data.IsActive,
                MasterMenuUrl = data.MasterMenuUrl,


            };




            return View(masterMenuModel);
        }

        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenuModel collection)
        {
            try
            {

                collection.EditUser = User.FindFirst(ClaimTypes.Name)?.Value;

            
          
                MasterMenu masterMenu = new()
                {
                    MasterMenuName = collection.MasterMenuName,
                    MasterMenuId = collection.MasterMenuId,
                    CreatDate = DateTime.Now,
                    CreatUser = collection.CreatUser,
                    EditDate = DateTime.Now,
                    EditUser = collection.EditUser,
                    IsActive = collection.IsActive,
                    MasterMenuUrl = collection.MasterMenuUrl

                };

                Repository.Update(id, masterMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Delete/5
        public ActionResult Delete(int deleteid)
        {
            var allowed = Repository.View().Where(x => x.IsDeleted == false && x.MasterMenuId != deleteid && x.IsActive && x.MasterMenuId != deleteid).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Delete(deleteid, null);

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Active(int id)
        {

            var allowed = Repository.View().Where(x => x.IsActive && x.MasterMenuId != id).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Active(id);


            return RedirectToAction(nameof(Index));
        }

        // POST: MasterMenuController/Delete/5






    }
}
