using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project.Validators.Attributes.UserControllerValidation
{
    public class UserByIdValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is User user)
            {
                if (user is null)
                {
                    ErrorMessage = "Wrong id! User does not exist!";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
