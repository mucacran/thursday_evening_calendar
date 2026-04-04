using System.ComponentModel.DataAnnotations.Schema;

namespace booking_calendar;

[Table("Meetings")]
public class Event
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [Column("date")]
    public DateTime Date { get; set; }
    [Column("description")]
    public string Description { get; set; } = string.Empty;
    [Column("courses_id")]
    public int? Course_Id { get; set; }
}