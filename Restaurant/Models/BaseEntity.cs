using System.ComponentModel.DataAnnotations;
namespace Restaurant.Models
{
    public class BaseEntity
    {
        public bool IsDeleted { get; set; }

        [Display(Name = "status")]
        public bool IsActive { get; set; }
        public string?CreatUser { get; set; }
        public DateTime?CreatDate { get; set; }
        public string? EditUser { get; set; }
        public DateTime?EditDate { get; set; }
    }
    public class BaseEntityTrans{
        public bool IsDeleted { get; set; }
        public string  ?CreatUser { get; set; }
        public DateTime ?CreatDate { get; set; }
    }
}