namespace TripApi.Models;

/// <summary>
/// Data model of tourist route picture
/// </summary>
public class TouristRoutePicture
{
    public int Id { get; set; }

    public string Url { get; set; }

    public Guid TouristRouteId { get; set; }

    public TouristRoute TouristRoute { get; set; }
}