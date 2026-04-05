using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace booking_calendar;

[Table("Course")]
public class Course
{
    public int Id { get; set; }
    public string? Name { get; set;}
    public string CourseId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int Priviledge { get; set; }
    

}