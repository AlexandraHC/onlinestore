using System;
using System.Collections.Generic;

namespace OnlineStore.Persistence.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public DateTime PaymentDate { get; set; }

    public int PaymentMethodId { get; set; }

    public bool IsSuccessful { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
