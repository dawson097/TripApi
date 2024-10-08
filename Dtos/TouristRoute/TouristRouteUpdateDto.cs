﻿using System.ComponentModel.DataAnnotations;

namespace TripApi.Dtos.TouristRoute;

public class TouristRouteUpdateDto : TouristRouteManipulationDto
{
    [Required(ErrorMessage = "描述不可为空"), MaxLength(1500)]
    public override string Description { get; set; }
}