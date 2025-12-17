using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterServices :BaseEntity
{
    [Display(Name = "Id")]
    public int MasterServicesId { get; set; }
    [Display(Name = "Title")]
    public string MasterServicesTitle { get; set; } = null!;

    [Display(Name = "describe")]
    public string MasterServicesDesc { get; set; } = null!;
    [Display(Name = "picture")]
    public string MasterServicesImage { get; set; } = null!;
}

