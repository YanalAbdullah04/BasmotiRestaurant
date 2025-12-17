using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterCategoryMenuController : Controller
    {

        public IRepository<MasterCategoryMenu> Repository { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> repository)
        {
            Repository = repository;
        }

        

        public ActionResult Index()
        {
            if(!User.Identity.IsAuthenticated)
                return RedirectToAction("LogIn","Account");
            var data = Repository.View();

            return View(data);
        }


        // GET: MasterCategoryMenuController/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogIn", "Account");

            return View();

        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenu collection)
        {
            try
            {


                if (!ModelState.IsValid)
                {

                    ModelState.AddModelError("", "error");
                    return View();
                }
                collection.IsActive = true;
                collection.IsDeleted = false;

                collection.CreatUser  = User.FindFirst(ClaimTypes.Name) ?.Value;
         

             
                Repository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogIn", "Account");
            var data = Repository.Find(id);


            return View(data);
        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenu collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "model state error");
                }
                collection.EditUser = User.FindFirst(ClaimTypes.Name)?.Value ;


                Repository.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Delete/5
        public ActionResult Delete(int deleteid)
        {
            var allowed = Repository.View().Where(x => x.IsDeleted==false && x.MasterCategoryMenuId != deleteid&&x.IsActive && x.MasterCategoryMenuId != deleteid).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Delete(deleteid, null);
         
            return RedirectToAction(nameof(Index));

        }
        public ActionResult Active(int id)
        {

            var allowed = Repository.View().Where(x => x.IsActive && x.MasterCategoryMenuId != id).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
           Repository.Active(id);


            return RedirectToAction(nameof(Index));
        }
        // POST: MasterCategoryMenuController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
