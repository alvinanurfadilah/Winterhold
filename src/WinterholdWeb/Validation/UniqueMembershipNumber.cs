using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WinterholdDataAccess.Models;

namespace WinterholdWeb.Validation;

public class UniqueMembershipNumber : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var dbContext = (WinterholdContext?)validationContext.GetService(typeof(WinterholdContext)) ?? throw new NullReferenceException("System Error");

            var isExists = dbContext.Customers.Any(
            cus => cus.MembershipNumber == value.ToString()
            );

            if (isExists)
            {
                return new ValidationResult($"{value.ToString()} already exists");
            }
        }

        return ValidationResult.Success;
    }
}
