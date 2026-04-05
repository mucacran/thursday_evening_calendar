using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace booking_calendar;

public class Course
{
    public int Id { get; set; }
    public string? Name { get; set;}
    public string CourseId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int Priviledge { get; set; }
    

}