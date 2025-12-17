using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterWorkingHoursModel :BaseEntity
    {
        public int MasterWorkingHoursId { get; set; }
        [Display(Name = "Name")]

        public string MasterWorkingHoursName { get; set; } = null!;
        [Display(Name = "working hours")]
        public string MasterWorkingHoursTimeFormTo { get; set; } = null!;
       


    }
}
