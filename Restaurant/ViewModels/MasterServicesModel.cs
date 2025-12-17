using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterServicesModel:BaseEntity
    {
        [Display(Name ="Id")]
        public int MasterServicesId { get; set; }
        [Display(Name ="Title")]
        public string MasterServicesTitle { get; set; } = null!;

        [Display(Name = "describe")]
        public string MasterServicesDesc { get; set; } = null!;
        [Display(Name = "picture")]
        public string? MasterServicesImage { get; set; } = null!;

        public IFormFile? File { get; set; }
    }
}
