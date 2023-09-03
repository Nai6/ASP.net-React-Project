using ASP.net_React_Project.Tools;
using ASP.net_React_Project.Validators.Attributes.UserControllerValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project;
[UserValidation]
public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    private string password = null!;

    public string Password
    {
        get
        {
            return PasswordEncryption.Decrypt(password);
        }
        set
        {
            password = PasswordEncryption.Encrypt(value);
        }
    }

    public string? Email { get; set; }

    public string Role { get; set; } = "user";

    public virtual Cart Cart { get; set; } = null!;

    public User()
    {
        Cart = new Cart();
    }
}
