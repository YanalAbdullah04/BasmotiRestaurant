using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterWorkingHoursController : Controller
    {
        public IRepository<MasterWorkingHours> Repository { get; }

        public MasterWorkingHoursController(IRepository<MasterWorkingHours>repository)
        {
            Repository = repository;
        }
        // GET: MasterWorkingHoursController
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }

            
            var data = Repository.View();

            return View(data);
        }

        // GET: MasterWorkingHoursController/Details/5


        // GET: MasterWorkingHoursController/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }


            return View();
        }

        // POST: MasterWorkingHoursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHoursModel collection)
        {
            try
            {
                collection.CreatUser = User.FindFirst(ClaimTypes.Name)?.Value;

                MasterWorkingHours masterWorkingHours = new()
                {
                    CreatUser = collection.CreatUser,
                    IsActive = collection.IsActive,
                    MasterWorkingHoursId = collection.MasterWorkingHoursId,
                    MasterWorkingHoursName = collection.MasterWorkingHoursName,
                    MasterWorkingHoursTimeFormTo = collection.MasterWorkingHoursTimeFormTo,
                };


                Repository.Add(masterWorkingHours);

                if (! ModelState.IsValid) {

                    ModelState.AddModelError("", "model error");
                    return View(collection);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHoursController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }


            var data = Repository.Find(id);


            MasterWorkingHoursModel masterWorkingHoursModel = new()
            {
                CreatDate = data.CreatDate,
                CreatUser = data.CreatUser,
                EditDate = data.EditDate,
                EditUser = data.EditUser,
                IsActive = data.IsActive,
                IsDeleted = data.IsDeleted,
                MasterWorkingHoursId = data.MasterWorkingHoursId,
                MasterWorkingHoursName = data.MasterWorkingHoursName,
                MasterWorkingHoursTimeFormTo = data.MasterWorkingHoursTimeFormTo

            };
            return View(masterWorkingHoursModel);
        }

        // POST: MasterWorkingHoursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHoursModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    ModelState.AddModelError("", "model error");
                    return View(collection);
                }

                collection.EditUser = User.FindFirst(ClaimTypes.Name)?.Value;
                MasterWorkingHours masterWorkingHours = new()
                {
                    CreatDate = collection.CreatDate,
                    CreatUser = collection.CreatUser,
                    EditDate = collection.EditDate,
                    EditUser
                    = collection.EditUser,
                    IsActive = collection.IsActive,
                    IsDeleted = collection.IsDeleted,
                    MasterWorkingHoursId = collection.MasterWorkingHoursId,
                    MasterWorkingHoursName = collection.MasterWorkingHoursName,
                    MasterWorkingHoursTimeFormTo = collection.MasterWorkingHoursTimeFormTo

                };
                Repository.Update(id, masterWorkingHours);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHoursController/Delete/5
        public ActionResult Delete(int deleteid)
        {
            var allowed = Repository.View().Where(x => x.IsDeleted == false && x.MasterWorkingHoursId != deleteid && x.IsActive && x.MasterWorkingHoursId != deleteid).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Delete(deleteid, null);

            return RedirectToAction(nameof(Index));

        }
        public ActionResult Active(int id)
        {

            var allowed = Repository.View().Where(x => x.IsActive && x.MasterWorkingHoursId != id).ToList();
            if (allowed.Count == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            Repository.Active(id);


            return RedirectToAction(nameof(Index));
        }



    }
}
