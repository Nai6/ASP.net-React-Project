using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project.Validators.Attributes.GoodControllerValidation
{
    public class AddingGoodValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is Good good)
            {
                if (good.Name is null)
                {
                    ErrorMessage = "Incorect data. Good must contain Name.";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
