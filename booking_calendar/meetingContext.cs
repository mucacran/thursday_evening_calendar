namespace booking_calendar;
using Microsoft.EntityFrameworkCore;

public class meetingContext : DbContext
{
    public meetingContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
