using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EquixAPI.Helpers.Validators
{
    public class EmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            string address = value.ToString();
            string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            Match match = Regex.Match(address.Trim(), pattern, RegexOptions.IgnoreCase);

            if (match.Success)
                return ValidationResult.Success;
            else
                return new ValidationResult("El email no es valido");
        }
    }
}
