using Microsoft.AspNetCore.Mvc.Rendering;
using TripsLog.Models;

public class TripViewModel
{
    public Trip Trip { get; set; }

    public List<SelectListItem> Destinations { get; set; }
    public List<SelectListItem> Accommodations { get; set; }
    public List<SelectListItem> Activities { get; set; }

    public List<int> SelectedActivityIds { get; set; }
}
