using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterOfferModel :BaseEntity
    {
        [Display(Name = "Id")]
        public int MasterOfferId { get; set; }
        [Display(Name = "Title")]
        public string MasterOfferTitle { get; set; } = null!;

        [Display(Name = "Breef")]
        public string MasterOfferBreef { get; set; } = null!;

        [Display(Name = "Descrip")]
        public string MasterOfferDesc { get; set; } = null!;

        [Display(Name = "picture")]
        public string? MasterOfferImageUrl { get; set; } = null!;
        public IFormFile? File { get; set; }

    }
}
