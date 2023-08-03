using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project.Validators.Attributes.UserControllerValidation
{
    public class RegistrationValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is User user)
            {
                if (user.Name is null)
                {
                    ErrorMessage = "User must have name";
                    return false;
                }
                else if (user.Password is null)
                {
                    ErrorMessage = "User must have password";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
