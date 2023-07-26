﻿using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project.Validators.Attributes
{
    public class UserValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is User user)
            {
                if (user.Name.Length <= 3)
                {
                    ErrorMessage = "The name must contain more than 2 characters";
                    return false;
                }
                else if (user.Password.Length <= 6)
                {
                    ErrorMessage = "The password must contain more than 5 characters";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
