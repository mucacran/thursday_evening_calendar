using booking_calendar.Components;

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
