using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace booking_calendar;

[Table("Meetings")]
public class Event
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }  
    [Column("date")]
    public DateTime Date { get; set; }
    [Column("description")]
    public string? Description { get; set; }  
    [Column("courses_id")]
    public int? CourseId { get; set; }  
    [JsonIgnore]
    public Course? Course { get; set; }
}