using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class AdminUserModel 
    {
        [Display(Name = "Full Name : ")]
        public string FullName { get; set; }
        [Display(Name = "Job Title :")]
        public string JobTitle { get; set; }

        [Display(Name = " Country :")]
        public string Country { get; set; }
        [Display(Name = "Address :")]
        public string Address { get; set; }

        [Display(Name = "Birth Date : ")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Phone:")]
        public string phoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name ="Twitter Account")]
        public string TwitterLink { get; set; }
        [Display(Name = "LinkedIn Account")]
        public string LinkedInLink { get; set; }
        [Display(Name = "FaceBook Account")]
        public string FaceBookLink { get; set; }
        [Display(Name = "Instegram Account")]
        public string InstegramLink { get; set; }

        public string imageurl { get; set; }
        public IFormFile ImageFile { get; set; }





    }
}
