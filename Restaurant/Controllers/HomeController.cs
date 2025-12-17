using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
       

        public IRepository<MasterMenu> MasterMenuRepository { get; }
        public IRepository<SystemSetting> SystemSettingRepository { get; }
        public IRepository<MasterSlider> MasterSliderRepository { get; }
        public IRepository<MasterItemMenu> MasterItemMenuRepository { get; }
        public IRepository<MasterFeedBack> MasterFeedBackRepository { get; }
        public IRepository<MasterOffer> MasterOfferRepository { get; }
        public IRepository<MasterPartner> MasterPartnerRepository { get; }
        public IRepository<MasterSocialMedia> MasterSocialMediarepository { get; }
        public IRepository<MasterWorkingHours> MasterWorkingHoursRepository { get; }
        public IRepository<TransactionBookTable> TransactionBookTableRepository { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletterRepository { get; }
        public IRepository<MasterServices> MasterServicesRepository { get; }
        public IRepository<TransactionContactUs> TransactionContactUsRepository { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenuRepository { get; }

        public HomeController(
            IRepository<MasterMenu>MasterMenuRepository,
            IRepository<SystemSetting> SystemSettingRepository,
            IRepository<MasterSlider>MasterSliderRepository,
            IRepository<MasterItemMenu> MasterItemMenuRepository,
            IRepository<MasterFeedBack> MasterFeedBackRepository,
            IRepository<MasterOffer> MasterOfferRepository,
            IRepository<MasterPartner> MasterPartnerRepository,
            IRepository<MasterSocialMedia> MasterSocialMediarepository,
            IRepository<MasterWorkingHours> MasterWorkingHoursRepository,
            IRepository<TransactionBookTable> TransactionBookTableRepository,
            IRepository<TransactionNewsletter> TransactionNewsletterRepository,
            IRepository<MasterServices> MasterServicesRepository,
            IRepository<TransactionContactUs> TransactionContactUsRepository,
            IRepository<MasterCategoryMenu> MasterCategoryMenuRepository





            )
        {
            this.MasterMenuRepository = MasterMenuRepository;
            this.SystemSettingRepository = SystemSettingRepository;
            this.MasterSliderRepository = MasterSliderRepository;
            this.MasterItemMenuRepository = MasterItemMenuRepository;
            this.MasterFeedBackRepository = MasterFeedBackRepository;
            this.MasterOfferRepository = MasterOfferRepository;
            MasterOfferRepository = MasterOfferRepository ;
            this.MasterPartnerRepository = MasterPartnerRepository;
            this.MasterSocialMediarepository = MasterSocialMediarepository;
            this.MasterWorkingHoursRepository = MasterWorkingHoursRepository;
            this.TransactionBookTableRepository = TransactionBookTableRepository;
            this.TransactionNewsletterRepository = TransactionNewsletterRepository;
            this.MasterServicesRepository = MasterServicesRepository;
            this.TransactionContactUsRepository = TransactionContactUsRepository;
            this.MasterCategoryMenuRepository = MasterCategoryMenuRepository;
        }


        public IActionResult Index()
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "modelstate error");

            }
            HomeModel homeModel = new()
            {
                masterMenuList = MasterMenuRepository.ViewClient(),
                SystemSetting = SystemSettingRepository.View().First(),
                MasterSliderList = MasterSliderRepository.ViewClient(),
                MasterItemMenuList = MasterItemMenuRepository.ViewClient().Where(x => !x.MasterCategoryMenu.MasterCategoryMenuName.ToLower().Contains("breakfast") && !x.MasterCategoryMenu.MasterCategoryMenuName.ToLower().Contains("party")).ToList(),

                FeedBacksList = MasterFeedBackRepository.ViewClient(),
                Offer = MasterOfferRepository.ViewClient().FirstOrDefault(),
                MasterPartnerList = MasterPartnerRepository.ViewClient(),
                MasterSocialList = MasterSocialMediarepository.ViewClient(),
                WorkingHoursList = MasterWorkingHoursRepository.ViewClient(),

                TransactionBookTable = new(),
                transactionNewsletter=new(),




            };




            

            return View(homeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookTable(HomeModel collection)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "modelstate error");

            }
            TransactionBookTable transactionBookTable = new TransactionBookTable()
            {
             CreatDate = DateTime.Now,
             TransactionBookTableDate = collection.TransactionBookTable.TransactionBookTableDate,
             TransactionBookTableEmail = collection.TransactionBookTable.TransactionBookTableEmail,  
             TransactionBookTableFullName = collection.TransactionBookTable.TransactionBookTableFullName,    
             TransactionBookTableId = collection.TransactionBookTable.TransactionBookTableId,
             TransactionBookTableMobileNumber = collection.TransactionBookTable.TransactionBookTableMobileNumber,    
             
             
                
            };
            TransactionBookTableRepository.Add(transactionBookTable);




            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewsLetter(HomeModel collection)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "modelstate error");

            }
            if (collection.transactionNewsletter == null)
            {
                return RedirectToAction(nameof(Index));
            }

            TransactionNewsletter transactionNewsletter = new()
            {
                TransactionNewsletterEmail = collection.transactionNewsletter.TransactionNewsletterEmail,


            };



           TransactionNewsletterRepository.Add(transactionNewsletter);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult AboutUs()
        {

            HomeModel model = new HomeModel()
            {

                SystemSetting = SystemSettingRepository.View().First(),
                MasterServicesList = MasterServicesRepository.ViewClient().Take(3).ToList(),
                masterMenuList=MasterMenuRepository.ViewClient(),
                MasterSocialList=MasterSocialMediarepository.ViewClient(),
                WorkingHoursList=MasterWorkingHoursRepository.ViewClient(),




            };

            



            return View(model);
        }
        public ActionResult ContactUs()
        {

            HomeModel model = new HomeModel()
            {
                SystemSetting = SystemSettingRepository.View().First(),
                masterMenuList = MasterMenuRepository.ViewClient(),
                TransactionContactUs=new TransactionContactUs(),
                transactionNewsletter=new(),
          MasterSocialList=MasterSocialMediarepository.ViewClient(),
          WorkingHoursList=MasterWorkingHoursRepository.ViewClient(),
          
          


                





            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(HomeModel collection)
        {

            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "modelstate error");
            //    return RedirectToAction(nameof(ContactUs));

            //}
            if (collection.TransactionContactUs == null)
            {
                return RedirectToAction(nameof(Index));
            }
            TransactionContactUsRepository.Add(collection.TransactionContactUs);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Menu()
        {
            HomeModel homeModel = new HomeModel()
            {
                SystemSetting = SystemSettingRepository.View().First(),
                masterMenuList = MasterMenuRepository.ViewClient(),
                MasterItemMenuList = MasterItemMenuRepository.ViewClient(),
                masterCategoryMenuList = MasterCategoryMenuRepository.ViewClient(),
                MasterPartnerList = MasterPartnerRepository.ViewClient(),
                MasterSocialList = MasterSocialMediarepository.ViewClient(),
                WorkingHoursList = MasterWorkingHoursRepository.ViewClient(),
                transactionNewsletter = new TransactionNewsletter(),


            };



            return View(homeModel);
        }


        public ActionResult ItemDetailes(int itemid)
        {

            HomeModel homeModel = new HomeModel()
            {
                MasterSocialList = MasterSocialMediarepository.ViewClient(),
                WorkingHoursList = MasterWorkingHoursRepository.ViewClient(),
                SystemSetting = SystemSettingRepository.View().First(),
                masterMenuList = MasterMenuRepository.ViewClient(),
                MasterItemMenuList = MasterItemMenuRepository.ViewClient().Where(x=>x.MasterItemMenuId == itemid).ToList(),



            };
            return View(homeModel);
        }
    }
}
