using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace storms.Models;

public class Storm
{
    [Key]
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly LandfallDate { get; set; }
    public int MaxWindSpeed { get; set; }
}