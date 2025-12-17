using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class MasterPartnerModel:BaseEntity
    {
        public int MasterPartnerId { get; set; }

        public string MasterPartnerName { get; set; } = null!;

        public string? MasterPartnerLogoImageUrl { get; set; } = null!;

        public string MasterPartnerWebsiteUrl { get; set; } = null!;
        public IFormFile? File { get; set; }
    }
}
