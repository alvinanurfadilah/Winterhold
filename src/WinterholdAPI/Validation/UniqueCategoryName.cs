using System.ComponentModel.DataAnnotations;
using WinterholdDataAccess.Models;

namespace WinterholdAPI.Validation;

public class UniqueCategoryName : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var dbContext = (WinterholdContext?)validationContext.GetService(typeof(WinterholdContext)) ?? throw new NullReferenceException("System Error");

            var isExists = dbContext.Categories.Any(
                cat => cat.Name == value.ToString()
            );

            if (isExists)
            {
                return new ValidationResult($"{value.ToString()} already exists");
            }
        }

        return ValidationResult.Success;
    }
}