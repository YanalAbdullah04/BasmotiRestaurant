using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterMenuModel
    {
        [Display(Name = "Id")]
        public int MasterMenuId { get; set; }
        [Display(Name = "Name")]
        public string MasterMenuName { get; set; } = null!;
        [Display(Name = "Url")]
        public string? MasterMenuUrl { get; set; } 

        public bool IsDeleted { get; set; }

        [Display(Name = "status")]
        public bool IsActive { get; set; }

        public string? CreatUser { get; set; }
        public DateTime? CreatDate { get; set; }
        public string? EditUser { get; set; }
        public DateTime? EditDate { get; set; }

 
    }
}
