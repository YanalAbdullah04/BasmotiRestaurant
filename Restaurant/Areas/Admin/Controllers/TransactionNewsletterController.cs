using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> Repository { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter>repository)
        {
            Repository = repository;
        }
        // GET: TransactionNewsletterController
        public ActionResult Index()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }

            var data = Repository.View();

            return View(data);
        }


    }
}
