using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterFeedBackModel :BaseEntity
    {



        public int MasterFeedBackId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string MasterCustomerName { get; set; }
        [Required]
        [Display(Name = "Description")]

        public string MasterFeedBackContent { get; set; }
 
        [Display(Name = "Customer photo")]

        public string? MasterFeedBackImageUrl { get; set; }



        [Display(Name = "Breef")]
        [Required]
        public string MasterFeedBackCustomerBreef { get; set; }
        public IFormFile? File { get; set; }
    }
}
