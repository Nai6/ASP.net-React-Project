using System;
using System.Collections.Generic;

namespace ASP.net_React_Project;

public partial class Good
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public byte[]? Img { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
