using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project.Validators.Attributes.GoodControllerValidation
{
    public class RemoveGoodValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is Good good)
            {
                if (good is null)
                {
                    ErrorMessage = "Incorect id.";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
