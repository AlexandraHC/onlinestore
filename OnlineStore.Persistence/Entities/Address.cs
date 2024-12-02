using System;
using System.Collections.Generic;

namespace OnlineStore.Persistence.Entities;

public partial class Address
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string StreetNumber { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
