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

    // This endpoint returns a simple list of mock events.
    [HttpGet]
    public IActionResult GetEvents()
    {
        // This creates a list to hold the sample events.
        var events = new List<Event>
        {
            // This adds the first sample event to the list.
            new Event
            {
                // This sets the event id.
                Id = 1,
                // This sets the event name.
                Name = "Team Planning Meeting",
                // This sets the event date.
                Date = new DateTime(2026, 4, 5),
                // This sets the event description.
                Description = "Discuss project goals and weekly tasks.",
                // This sets the course id.
                Course_Id = 310
            },
            // This adds the second sample event to the list.
            new Event
            {
                // This sets the event id.
                Id = 2,
                // This sets the event name.
                Name = "Database Review",
                // This sets the event date.
                Date = new DateTime(2026, 4, 8),
                // This sets the event description.
                Description = "Review table structure and sample records.",
                // This sets the course id.
                Course_Id = 325
            },
            // This adds the third sample event to the list.
            new Event
            {
                // This sets the event id.
                Id = 3,
                // This sets the event name.
                Name = "Final Presentation Prep",
                // This sets the event date.
                Date = new DateTime(2026, 4, 12),
                // This sets the event description.
                Description = "Prepare slides and practice the final presentation.",
                // This sets the course id.
                Course_Id = 310
            }
        };

        // This returns the list of mock events with a 200 OK response.
        return Ok(events);
    }

    [HttpPut]
    public async Task<IActionResult> AddEvent (Event evt)
    {
        _db.Events.Add(evt);
        await _db.SaveChangesAsync();
        return Ok(evt);
    }

}
