using System.ComponentModel.DataAnnotations;
using MVCWebApplication1.Helpers;

namespace MVCApplication1.Attributes;

public class PositiveNonZeroAttribute : ValidationAttribute
{

  protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
  {
    try
    {

      if (value == null)
      {
        return ValidationResult.Success!; // Null values are handled by the Required attribute
      }

      var propertyType = validationContext.ObjectType.GetProperty(validationContext.MemberName ?? "")?.PropertyType;

      if (propertyType != null && propertyType.IsNumericType())
      {
        if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
          // Get the underlying type of the nullable type
          propertyType = Nullable.GetUnderlyingType(propertyType)!;
        }

        dynamic numericValue = Convert.ChangeType(value, propertyType);

        if (numericValue <= 0)
        {
          return new ValidationResult(ErrorMessage ?? $"{validationContext.MemberName} must be a positive non-zero {propertyType.Name.ToLower()}");
        }
      }
      else
      {
        throw new ArgumentException("The attribute can only be applied to numeric properties.");
      }

      return ValidationResult.Success!;
    }
    catch (Exception ex)
    {
      return new ValidationResult(ex.Message);
    }
  }
}