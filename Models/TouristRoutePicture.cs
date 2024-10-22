using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripApi.Models;

/// <summary>
/// Data model of tourist route picture
/// </summary>
public class TouristRoutePicture
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Url { get; set; }

    [ForeignKey("TouristRouteId")]
    public Guid TouristRouteId { get; set; }

    public TouristRoute TouristRoute { get; set; }
}