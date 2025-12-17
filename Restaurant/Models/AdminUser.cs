using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class AdminUser :IdentityUser
    {
        [Display(Name ="Full Name : ")]
        public string FullName { get; set; }
        [Display(Name = "Job Title :")]
        public string JobTitle { get; set; }

        [Display(Name = ":")]
        public string Country { get; set; }
        [Display(Name = ":")]
        public string Address { get; set; }

        [Display(Name = "Birth Date : ")]
        public DateTime BirthDate { get; set; }

        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public string FaceBookLink { get; set; }
        public string InstegramLink { get; set; }

        public string imageurl { get; set; }
  




    }
}
