using ASP.net_React_Project.Validators.Attributes.GoodControllerValidation;
using System;
using System.Collections.Generic;

namespace ASP.net_React_Project;

[GoodValidation]
public partial class Good
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Price { get; set; }

    public byte[]? Img { get; set; }

    public int? Quantity { get; set; }
}
