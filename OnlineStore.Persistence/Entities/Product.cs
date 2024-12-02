using System;
using System.Collections.Generic;

namespace OnlineStore.Persistence.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public decimal PriceWithoutVat { get; set; }

    public decimal PriceWithVat { get; set; }

    public int CategoryId { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
