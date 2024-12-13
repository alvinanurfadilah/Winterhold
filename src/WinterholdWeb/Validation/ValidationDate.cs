using System.ComponentModel.DataAnnotations;
using WinterholdDataAccess.Models;
using WinterholdWeb.Validation;

namespace WinterholdWeb;

public class ValidationDate : ValidationAttribute
{
    // protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    // {


    //     if ((DateTime)value > DateTime.Now.AddYears(2))
    //     {
    //         return new ValidationResult("Value is invalid");
    //     }

    //     return ValidationResult.Success;
    // }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var book = validationContext.ObjectInstance as Book; // book nama view model
        if (book != null)
        {
            return base.IsValid(value, validationContext);
        }
        return ValidationResult.Success;
    }   
}