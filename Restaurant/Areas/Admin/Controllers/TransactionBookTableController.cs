using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> Repository { get; }

        public TransactionBookTableController(IRepository<TransactionBookTable>repository)
        {
            Repository = repository;
        }
        // GET: TransactionBookTableController
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
               return RedirectToAction("LogIn","Account");
            }
            var data = Repository.View();


            return View(data);
        }



    
    }
}
