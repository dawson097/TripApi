﻿using System.Text.RegularExpressions;

namespace TripApi.ResourceParameters;

/// <summary>
/// Tourist route resource filter
/// </summary>
public class TouristRouteResourceParameters
{
    public string Keyword { get; set; }

    private string _rating;

    public string Rating
    {
        get => _rating;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var regex = new Regex(@"([A-Za-z0-9\-]+)(\d+)");
                var match = regex.Match(value);

                if (match.Success)
                {
                    RatingOperator = match.Groups[1].Value;
                    RatingValue = int.Parse(match.Groups[2].Value);
                }
            }

            _rating = value;
        }
    }

    public string RatingOperator { get; set; }

    public int? RatingValue { get; set; }
}