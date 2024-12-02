﻿using System;
using System.Collections.Generic;

namespace OnlineStore.Persistence.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
