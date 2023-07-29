using ASP.net_React_Project.Validators.Attributes.CartControllerValidation;
using System;
using System.Collections.Generic;

namespace ASP.net_React_Project;

[CartValidation]
public partial class Cart
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? GoodsId { get; set; }

    public virtual Good? Goods { get; set; }

    public virtual User? User { get; set; }
}
