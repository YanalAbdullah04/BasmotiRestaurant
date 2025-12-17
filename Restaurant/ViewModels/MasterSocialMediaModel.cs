using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterSocialMediaModel :BaseEntity
    {
        [Display(Name = "Id")]
        public int MasterSocialMediaId { get; set; }
        [Display(Name = "Image")]
        public string? MasterSocialMediaImageUrl { get; set; } = null!;
        [Display(Name = "Link")]
        public string MasterSocialMediaUrl { get; set; } = null!;
        public IFormFile? File { get; set; }

    }
}
