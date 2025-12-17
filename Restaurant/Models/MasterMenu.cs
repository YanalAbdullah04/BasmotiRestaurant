using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterMenu :BaseEntity
{

    [Display (Name ="Id")]
    public int MasterMenuId { get; set; }
    [Display(Name = "Name")]
    public string MasterMenuName { get; set; } = null!;
    [Display(Name = "url")]


    public string MasterMenuUrl { get; set; } = null!;
}
