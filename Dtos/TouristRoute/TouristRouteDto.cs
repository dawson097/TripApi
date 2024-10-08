﻿using TripApi.Dtos.TouristRoutePicture;

namespace TripApi.Dtos.TouristRoute;

public class TouristRouteDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }

    public DateTime? DepartureTime { get; set; }

    public string Features { get; set; }

    public string Fees { get; set; }

    public string Notes { get; set; }

    public double? Rating { get; set; }

    public string TripDays { get; set; }

    public string TripType { get; set; }

    public string DepartureCity { get; set; }

    public ICollection<TouristRoutePictureDto> TouristRoutePictures { get; set; }
}