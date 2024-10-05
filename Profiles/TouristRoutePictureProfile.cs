using AutoMapper;
using TripApi.Dtos.TouristRoutePicture;
using TripApi.Models;

namespace TripApi.Profiles;

/// <summary>
/// DTO mapper configuration of tourist route picture
/// </summary>
public class TouristRoutePictureProfile : Profile
{
    public TouristRoutePictureProfile()
    {
        CreateMap<TouristRoutePicture, TouristRoutePictureDto>();
    }
}