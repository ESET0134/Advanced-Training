using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Collage_App.Model.Validators
{
    // ✅ Date Validation - must be greater than today's date
    public class DateCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = value as DateTime?;

            if (date == null)
            {
                return new ValidationResult("Please enter a date.");
            }

            // Compare only date part (ignore time)
            if (date.Value.Date <= DateTime.Now.Date)
            {
                return new ValidationResult("Date must be greater than today's date.");
            }

            return ValidationResult.Success;
        }
    }

    // ✅ Space Validation - no spaces allowed
    public class SpaceCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var input = value as string;

            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult("Please enter a valid value.");
            }

            if (input.Contains(" "))
            {
                return new ValidationResult("Spaces are not allowed.");
            }

            return ValidationResult.Success;
        }
    }

    // ✅ Capital Case Validation

    public class CapitalCaseAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var input = value as string;

            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult("Please enter a valid value.");
            }
            var regex = new Regex(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)*$");

            if (!regex.IsMatch(input))
            {
                return new ValidationResult("Each word in the name must start with a capital letter.");
            }

            return ValidationResult.Success;
        }
    }
}