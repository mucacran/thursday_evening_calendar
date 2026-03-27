using System.ComponentModel.DataAnnotations.Schema;

namespace booking_calendar;

[Table("Meetings")]
public class Event
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }  
    [Column("date")]
    public DateTime Date { get; set; }
    [Column("description")]
    public string Description { get; set; }  
    [Column("course_id")]
    public int Course_Id { get; set; }  
}