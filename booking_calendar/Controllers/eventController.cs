using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace booking_calendar;

[Route("addEvents")]
[ApiController]

public class EventController : Controller
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
