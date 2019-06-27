using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.CustomValidations
{
    public class DivisibleBy10Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var price = Convert.ToDouble(value);

            if (price % 10 == 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(this.ErrorMessage);
            }
        }
    }
}