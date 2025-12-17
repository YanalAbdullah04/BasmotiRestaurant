using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterFeedBack :BaseEntity
    {
 
        public int MasterFeedBackId { get; set; }
      
        [Required]
        [Display(Name = "Name")]
        public string MasterCustomerName { get; set; }
        [Required]
        [Display(Name = "Description")]

        public string MasterFeedBackContent { get; set; }
        [Required]
        [Display(Name = "Customer photo")]

        public string MasterFeedBackImageUrl { get; set; }
     


        [Display(Name = "Breef")]
        [Required]
        public string MasterFeedBackCustomerBreef { get; set; }


    }
}
