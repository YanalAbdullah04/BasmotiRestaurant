using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionContactUsController : Controller
    {
        private  IRepository<TransactionContactUs> Repository;

        public TransactionContactUsController(IRepository<TransactionContactUs> Repository)
        {
            this.Repository = Repository;
        }
        // GET: TransactionContactUsController
        public ActionResult Index()
        {

            if(! User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }
            var data = Repository.View();

            return View(data);
        }


    }
}
