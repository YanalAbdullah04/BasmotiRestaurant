using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterSlider :BaseEntity
{
    [Display(Name ="Id")]
    public int MasterSliderId { get; set; }
    [Display(Name = "Title")]
    public string MasterSliderTitle { get; set; } = null!;
    [Display(Name = "Breef")]
    public string MasterSliderBreef { get; set; } = null!;
    [Display(Name = "Describe")]
    public string MasterSliderDesc { get; set; } = null!;
    [Display(Name = "image")]
    public string MasterSliderImageUrl { get; set; } = null!;
}
