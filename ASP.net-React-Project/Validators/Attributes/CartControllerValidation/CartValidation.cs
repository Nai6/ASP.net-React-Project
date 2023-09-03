using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project.Validators.Attributes.CartControllerValidation
{
    public class CartValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is Cart cart)
            {
                if(cart.UserId is null)
                {
                    ErrorMessage = "Cart must contain User and Good id";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
