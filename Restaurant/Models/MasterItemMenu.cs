using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterItemMenu :BaseEntity
{
    [Display(Name ="Id")]
    public int MasterItemMenuId { get; set; }

    public int MasterCategoryMenuId { get; set; }

    [Display(Name = "Title")]
    public string MasterItemMenuTitle { get; set; } = null!;
    [Display(Name = "Breef")]
    public string MasterItemMenuBreef { get; set; } = null!;
    [Display(Name = "Descripe")]
    public string MasterItemMenuDesc { get; set; } = null!;

    [Display(Name = "Price")]
    public double MasterItemMenuPrice { get; set; }
    [Display(Name = "photo")]
    public string MasterItemMenuImageUrl { get; set; } = null!;

     [Display(Name = "Date")]
    public DateTime MasterItemMenuDate { get; set; }

    public  MasterCategoryMenu? MasterCategoryMenu { get; set; } 
}
