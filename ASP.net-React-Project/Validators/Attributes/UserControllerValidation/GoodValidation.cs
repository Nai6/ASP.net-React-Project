using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project.Validators.Attributes.UserControllerValidation
{
    public class GoodValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is Good good)
            {
                if (good.Name.Length < 10)
                {
                    ErrorMessage = "The good's name must contain more than 10 characters";
                    return false;
                }
                else if (good.Price < 0)
                {
                    ErrorMessage = "Price can't be less that 0";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
