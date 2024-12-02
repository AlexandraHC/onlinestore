using System;
using System.Collections.Generic;

namespace OnlineStore.Persistence.Entities;

public partial class Invoice
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public string? InvoiceNumber { get; set; }

    public decimal TotalAmountWithoutVat { get; set; }

    public decimal TotalAmountWithVat { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
