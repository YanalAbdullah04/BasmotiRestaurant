using System;
using System.Collections.Generic;

namespace Restaurant.Models;

public partial class TransactionContactUs:BaseEntityTrans
{
    public int TransactionContactUsId { get; set; }

    public string? TransactionContactUsFullName { get; set; } = null!;

    public string? TransactionContactUsEmail { get; set; } = null!;

    public string? TransactionContactUsSubject { get; set; } = null!;

    public string? TransactionContactUsMessage { get; set; } = null!;
}
