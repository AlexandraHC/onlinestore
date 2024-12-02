using System;
using System.Collections.Generic;

namespace OnlineStore.Persistence.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmountWithoutVat { get; set; }

    public decimal TotalAmountWithVat { get; set; }

    public string? Remarks { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
