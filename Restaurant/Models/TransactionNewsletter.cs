using System;
using System.Collections.Generic;

namespace Restaurant.Models;

public partial class TransactionNewsletter :BaseEntityTrans
{
    public int TransactionNewsletterId { get; set; }

    public string TransactionNewsletterEmail { get; set; } = null!;
}
