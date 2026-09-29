using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// wwwroot/index.html ko homepage banata hai
app.UseDefaultFiles();
app.UseStaticFiles();

// Health check
app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

// Server ki info dikhata hai - deploy check karne ke liye
app.MapGet("/api/info", () => new
{
    message = "Hello from Azure App Service! 🚀",
    appServiceName = Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME") ?? "Running locally",
    machineName = Environment.MachineName,
    os = RuntimeInformation.OSDescription,
    dotnetVersion = RuntimeInformation.FrameworkDescription,
    serverTimeUtc = DateTime.UtcNow
});

app.Run();