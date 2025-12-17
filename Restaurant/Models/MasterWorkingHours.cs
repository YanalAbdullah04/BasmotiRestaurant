using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterWorkingHours :BaseEntity
{
    [Display(Name = "Id")]
    
    public int MasterWorkingHoursId { get; set; }
    [Display(Name = "Name")]

    public string MasterWorkingHoursName { get; set; } = null!;
    [Display(Name = "working hours")]
    public string MasterWorkingHoursTimeFormTo { get; set; } = null!;
}
