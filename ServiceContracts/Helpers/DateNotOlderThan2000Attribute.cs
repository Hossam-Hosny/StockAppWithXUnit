using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.ValidationClass
{
    public class DateNotOlderThan2000Attribute : ValidationAttribute
    {
        protected  override  ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date && date < new DateTime(2000, 1, 1))
            {
                return new ValidationResult("The date can not be older than 1/1/2000");
            }
            return ValidationResult.Success;
        }

    }
}
