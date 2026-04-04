using System.ComponentModel.DataAnnotations;

namespace booking_calendar;

public class EventModel
{
    [Required]
    public string Name { get; set; } = string.Empty;

    // Course_Id must be int to match Event model
    public int? Course_Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
}