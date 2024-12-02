using System;
using System.Collections.Generic;

namespace OnlineStore.Persistence.Entities;

public partial class OrderLine
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal PriceWithVat { get; set; }

    public decimal PriceWithoutVat { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
