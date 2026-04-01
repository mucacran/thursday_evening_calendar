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

    [HttpPut]
    public async Task<IActionResult> AddEvent (Event evt)
    {
        _db.Events.Add(evt);
        await _db.SaveChangesAsync();
        return Ok(evt);
    }

}
