using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace storms.Models;

public class Storm
{
    [Key]
    public string Id { get; set; }
    public string? Basin { get; set; }
    public int? CycloneNumber { get; set; }
    public int Year { get; set; }
    public string? Name { get; set; }
    // Longitude and latitude should be double/float, stored as +/- instead of N/S or E/W
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    public bool IsLandfall { get; set; }
    public DateTime LandfallDateTime { get; set; }
    public int MaxWindSpeed { get; set; }
}