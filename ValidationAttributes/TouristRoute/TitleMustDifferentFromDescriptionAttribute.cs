using System.ComponentModel.DataAnnotations;
using TripApi.Dtos.TouristRoute;

namespace TripApi.ValidationAttributes.TouristRoute;

public class TitleMustDifferentFromDescriptionAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var routeDto = (TouristRouteManipulationDto)validationContext.ObjectInstance;

        if (routeDto.Title == routeDto.Description)
        {
            return new ValidationResult("路线名称必须与路线描述不同", new[] { "TouristRouteAddDto" });
        }

        return ValidationResult.Success;
    }
}