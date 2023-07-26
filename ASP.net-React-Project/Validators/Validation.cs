using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project.Validators
{
    public class Validation<TValue>
    {
        public void Validate(TValue ValidationObject)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(ValidationObject);
            if (!Validator.TryValidateObject(ValidationObject, context, results, true))
            {
                foreach (var error in results)
                {
                    Results.BadRequest(new { message = $"{error.ErrorMessage}" });
                }
            }
        }
    }
}