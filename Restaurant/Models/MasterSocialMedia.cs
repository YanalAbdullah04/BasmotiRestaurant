using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterSocialMedia :BaseEntity
{
    [Display (Name ="Id")]
    public int MasterSocialMediaId { get; set; }
    [Display(Name = "Image")]
    public string MasterSocialMediaImageUrl { get; set; } = null!;
    [Display(Name = "Link")]
    public string MasterSocialMediaUrl { get; set; } = null!;
}
