using System.ComponentModel.DataAnnotations;

namespace booking_calendar;

public class EventModel
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Course { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
}