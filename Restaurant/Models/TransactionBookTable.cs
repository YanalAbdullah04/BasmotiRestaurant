using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class TransactionBookTable :BaseEntityTrans
{

    public int TransactionBookTableId { get; set; }

    [Display(Name =" Client's Full Name")]
    public string TransactionBookTableFullName { get; set; } = null!;

    [Display(Name = " Client's Email")]
    public string TransactionBookTableEmail { get; set; } = null!;
    [Display(Name = " Client's Number")]

    public string TransactionBookTableMobileNumber { get; set; } = null!;
    [Display(Name = " Booked Date")]

    public DateTime TransactionBookTableDate { get; set; }
}
