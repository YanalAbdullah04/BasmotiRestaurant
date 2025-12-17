using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class HomeModel
    {
        public List<MasterMenu> masterMenuList { get; set; }
        public SystemSetting SystemSetting { get; set; }
        public List<MasterSlider> MasterSliderList { get; set; }
        public List<MasterItemMenu> MasterItemMenuList { get; set; }
        public List<MasterFeedBack> FeedBacksList { get; set; }
        public MasterOffer Offer { get; set; }
        public List<MasterPartner> MasterPartnerList { get; set; }
        public List<MasterSocialMedia> MasterSocialList { get; set; }
        public List<MasterWorkingHours> WorkingHoursList { get; set; }






        public TransactionBookTable TransactionBookTable  { get; set; }
        public TransactionNewsletter transactionNewsletter  { get; set; }
     
        public List<MasterServices> MasterServicesList { get; set; }
        public List<MasterPartner> PartnersList { get; set; }
        public TransactionContactUs TransactionContactUs { get; set; }
        public List<MasterCategoryMenu> masterCategoryMenuList { get; set; }
  






    }
}
