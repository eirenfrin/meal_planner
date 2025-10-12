using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Backend.Validators;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public partial class PasswordValidatorAttribute : ValidationAttribute
{
    [GeneratedRegex("[A-Z]")]
    private static partial Regex UppercaseRegex();

    [GeneratedRegex("[a-z]")]
    private static partial Regex LowercaseRegex();

    [GeneratedRegex("[0-9]")]
    private static partial Regex NumberRegex();

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Password is required.");
        }

        var password = value.ToString()!;
        var errors = new List<string>();

        if (password.Length < 6)
        {
            errors.Add("Password must be at least 6 characters long.");
        }

        if (!UppercaseRegex().IsMatch(password))
        {
            errors.Add("Password must contain at least one uppercase letter.");
        }

        if (!LowercaseRegex().IsMatch(password))
        {
            errors.Add("Password must contain at least one lowercase letter.");
        }

        if (!NumberRegex().IsMatch(password))
        {
            errors.Add("Password must contain at least one number.");
        }

        if (errors.Count != 0)
        {
            return new ValidationResult(string.Join(" ", errors));
        }

        return ValidationResult.Success;
    }
}