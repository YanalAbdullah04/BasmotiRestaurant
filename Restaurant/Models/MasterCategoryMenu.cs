using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterCategoryMenu : BaseEntity
{

    [Display(Name ="Id")]
    public int MasterCategoryMenuId { get; set; }

    [Display(Name ="category")]
    public string MasterCategoryMenuName { get; set; } = null!;


 
}
