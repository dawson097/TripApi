using AutoMapper;
using TripApi.Dtos.TouristRoute;
using TripApi.Models;

namespace TripApi.Profiles;

/// <summary>
/// DTO mapper configuration of tourist route
/// </summary>
public class TouristRouteProfile : Profile
{
    public TouristRouteProfile()
    {
        CreateMap<TouristRoute, TouristRouteDto>()
            .ForMember(
                des => des.Price,
                opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscoutPresent ?? 1))
            )
            .ForMember(
                des => des.TripDays,
                opt => opt.MapFrom(src => src.TripDays.ToString())
            )
            .ForMember(
                des => des.TripType,
                opt => opt.MapFrom(src => src.TripType.ToString())
            )
            .ForMember(
                des => des.DepartureCity,
                opt => opt.MapFrom(src => src.DepartureCity.ToString())
            );

        CreateMap<TouristRouteAddDto, TouristRoute>()
            .ForMember(
                des => des.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
            );
    }
}