

/***********************************************************************************
 * This is the main entry point of the application. It sets up the web application
 * and configures the services and middleware that will be used throughout the app.
 * It also maps the controllers and Razor components to their respective routes.
    * The application is built using ASP.NET Core and follows the MVC pattern, with
    * Razor components for the frontend and API controllers for handling HTTP requests.
***********************************************************************************/
using Microsoft.EntityFrameworkCore;
using booking_calendar.Components;
using Microsoft.AspNetCore.Components;

/***********************************************************************************
 * The booking_calendar namespace contains all the classes and components related to
 * the booking calendar application. This includes the DbContext for managing events,
 * the API controllers for handling HTTP requests, and any Razor components used in
 * the frontend of the application. By organizing the code into a namespace, we can keep related classes together and avoid naming conflicts with classes from other libraries or parts of the application.
***********************************************************************************/
using booking_calendar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

/***********************************************************************************
 * AddControllers is a method that adds services for controllers to the service collection.
 * This is necessary for our API controllers to work, as it allows us to use features such
 * as model binding, validation, and routing. By calling this method, we are telling the
 * application that we want to use controllers to handle HTTP requests and return responses
 * in our application.
***********************************************************************************/
builder.Services.AddControllers(); // add controllers to the service collection
builder.Services.AddHttpClient(); // add HttpClient to the service collection, which allows us to make HTTP requests to our API controllers from our Razor components

// Configure HttpClient with BaseAddress for Blazor Server components
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(sp.GetRequiredService<NavigationManager>().BaseUri)
});

/***********************************************************************************
 * Database Configuration - Safely connects to MySQL with InMemory fallback
 * 
 * This setup reads the connection string from configuration (user-secrets or appsettings).
 * If no connection string is found, it falls back to an in-memory database for local testing.
 * 
 * IMPORTANT: Never commit real passwords to source control!
 * To set your connection string securely, use user-secrets:
 *   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=your-host;Database=your-db;User=your-user;Password=your-password;Port=3306;SslMode=Required;"
 * 
 * MySQL version is set explicitly to avoid startup connection attempts.
***********************************************************************************/

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (!string.IsNullOrEmpty(connectionString))
{
    // Use MySQL with explicit server version (avoids AutoDetect connection at startup)
    builder.Services.AddDbContext<meetingContext>(options =>
        options.UseMySql(connectionString, 
            new MySqlServerVersion(new Version(8, 0, 21)))
    );
    
    // Log that we're using MySQL (safe - no password printed)
    Console.WriteLine($"[Database] Using MySQL connection");
}
else
{
    // Fallback to InMemory database if no connection string configured
    builder.Services.AddDbContext<meetingContext>(options =>
        options.UseInMemoryDatabase("CalendarTestDb")
    );
    
    Console.WriteLine("[Database] WARNING: No connection string found. Using InMemory database (data will not persist).");
    Console.WriteLine("[Database] To configure MySQL, use: dotnet user-secrets set \"ConnectionStrings:DefaultConnection\" \"Server=...\"");
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
/***********************************************************************************
 * MapControllers is a method that maps attribute-routed API controllers.
 * This means that it will look for any classes that have the [ApiController]
 * attribute and map their routes based on the attributes defined on their methods
 * (e.g., [HttpGet], [HttpPost], etc.). This allows us to define our API endpoints
 * in a clean and organized way, without having to manually configure each route in
 * the startup configuration.
***********************************************************************************/
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
