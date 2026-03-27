using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace booking_calendar;

[Route("addEvents")]
[ApiController]

public class EventController : Controller
{
    private readonly meetingContext _db;
}