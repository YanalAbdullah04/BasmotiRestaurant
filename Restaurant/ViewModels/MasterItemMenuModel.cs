using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class MasterItemMenuModel:BaseEntity
    {

        public int MasterItemMenuId { get; set; }

        public int MasterCategoryMenuId { get; set; }

        public string MasterItemMenuTitle { get; set; } = null!;

        public string MasterItemMenuBreef { get; set; } = null!;

        public string MasterItemMenuDesc { get; set; } = null!;

        public double MasterItemMenuPrice { get; set; }

        public string? MasterItemMenuImageUrl { get; set; }

        public DateTime MasterItemMenuDate { get; set; }

        public  MasterCategoryMenu? MasterCategoryMenu { get; set; } 
        public IFormFile? File { get; set; }
    }
}
