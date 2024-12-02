using System;
using System.Collections.Generic;

namespace OnlineStore.Persistence.Entities;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
