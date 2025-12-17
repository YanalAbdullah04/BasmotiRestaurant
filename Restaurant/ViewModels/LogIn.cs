using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class LogIn
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        
        public string Password  { get; set; }


        [Display(Name ="remmber me")]
        public bool RemmberMe { get; set; }

    }
}
