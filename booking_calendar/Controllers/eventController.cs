using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace booking_calendar;

// api controller for events
// this is a simple controller that allows us to add events to the database
[Route("api/events")]
[ApiController]

//ControllerBase is a base class for an MVC controller without view support. It provides the basic functionality for handling HTTP requests and returning responses, but does not include any view rendering capabilities. This makes it ideal for building APIs that return data in formats such as JSON or XML, rather than HTML views.
public class EventController : ControllerBase // this is a simple controller that allows us to add events to the database
{
    private readonly meetingContext _db;

    public EventController(meetingContext context)
    {
        _db = context;
    }

    // This endpoint returns the list of events from the database.
    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {
        // This queries all events from the database.
        var events = await _db.Events
            .Select(e => new EventListItemDto
            {
                Id = e.Id,
                Name = e.Name ?? string.Empty,
                Date = e.Date,
                Description = e.Description ?? string.Empty,
                CourseId = e.CourseId ?? 0  // Use 0 if CourseId is null
            })
            .ToListAsync();

        // This returns the real data from the database.
        return Ok(events);
    }

    // This endpoint returns available courses so the UI can send valid CourseId values.
    [HttpGet("courses")]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _db.Courses
            .OrderBy(c => c.Id)
            .Select(c => new CourseListItemDto
            {
                Id = c.Id,
                Name = string.IsNullOrWhiteSpace(c.Name) ? $"Course {c.Id}" : c.Name
            })
            .ToListAsync();

        return Ok(courses);
    }

    // Use HttpPost for creating new resources (HttpPut is for updates)
    [HttpPost]
    public async Task<IActionResult> AddEvent([FromBody] EventModel model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var normalizedCourseId = model.CourseId.GetValueOrDefault() == 0 ? null : model.CourseId;

        if (normalizedCourseId.HasValue)
        {
            var courseExists = await _db.Courses.AnyAsync(c => c.Id == normalizedCourseId.Value);
            if (!courseExists)
            {
                return BadRequest(new
                {
                    message = $"CourseId {normalizedCourseId.Value} no existe en Course. Usa 0/null o un Id valido."
                });
            }
        }

        // Map EventModel to Event entity
        var evt = new Event
        {
            Name = model.Name,
            Date = model.Date,
            Description = model.Description ?? string.Empty,
            // Convert 0 to null for CourseId (when input is empty, it sends 0)
            CourseId = normalizedCourseId
        };

        try
        {
            _db.Events.Add(evt);
            await _db.SaveChangesAsync();
            return Ok(evt);
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, new
            {
                message = "No se pudo guardar el evento en la base de datos.",
                detail = ex.InnerException?.Message ?? ex.Message
            });
        }
    }

    // This DTO keeps the list view response simple and read-only.
    private class EventListItemDto
    {
        // This stores the event id.
        public int Id { get; set; }

        // This stores the event name and defaults to an empty value if needed later.
        public string Name { get; set; } = string.Empty;

        // This stores the event date.
        public DateTime Date { get; set; } = DateTime.Now;

        // This stores the event description and defaults to an empty value if needed later.
        public string Description { get; set; } = string.Empty;

        // This stores the course id with a consistent read-only name.
        public int CourseId { get; set; }
    }

    // This DTO is used by the add-event form to display valid course IDs.
    private class CourseListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

}


