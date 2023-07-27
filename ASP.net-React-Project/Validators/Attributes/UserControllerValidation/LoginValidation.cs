using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project.Validators.Attributes.UserControllerValidation
{
    public class LoginValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is User user)
            {
                if (user.Name == null || user.Password == null)
                {
                    ErrorMessage = "Username of password can't be empty";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
