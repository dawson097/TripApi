using AutoMapper;
using TripApi.Dtos.TouristRoutePicture;
using TripApi.Models;

namespace TripApi.Profiles;

public class TouristRoutePictureProfile : Profile
{
    public TouristRoutePictureProfile()
    {
        CreateMap<TouristRoutePicture, TouristRoutePictureDto>();
    }
}