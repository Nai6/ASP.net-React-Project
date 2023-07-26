using ASP.net_React_Project.Tools;
using ASP.net_React_Project.Validators.Attributes;
using System;
using System.Collections.Generic;

namespace ASP.net_React_Project;
[UserValidation]
public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    private string password;

    public string Password
    {
        get
        {
            return password;
        }
        set
        {
            password = PasswordEncryption.Encrypt(value);
        }
    }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
