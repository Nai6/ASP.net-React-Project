using ASP.net_React_Project.Validators.Attributes.GoodControllerValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace ASP.net_React_Project.Validators
{
    public class Validation<TValue>
    {
        public ValidationData Validate(TValue ValidationObject, ValidationAttribute attribute)
        {
            var context = new ValidationContext(ValidationObject);
            var results = new List<ValidationResult>();
            ValidationData validationData = new ValidationData();
            List<ValidationAttribute> Attribute = new List<ValidationAttribute>() { attribute };
            if (!Validator.TryValidateValue(ValidationObject, context, results, Attribute))
            {
                foreach (var error in results)
                {
                    validationData.ListOfErrors.Add(error.ToString());
                }
            }
            return validationData;
        }
    }
}