using Sentry;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.WebHost.UseSentry();
LoggerConfiguration loggerConfiguration = new LoggerConfiguration();
builder.Host.UseSerilog((context,configuration) => configuration.ReadFrom.Configuration(context.Configuration));
Log.Logger = loggerConfiguration.MinimumLevel.Override("Microsoft",LogEventLevel.Information).Enrich.FromLogContext().WriteTo.Console().CreateLogger();
builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://c8caa5668f224e7e9ac4f6933d8f1ca4@o4505465599754240.ingest.sentry.io/4505465738756096";
    o.Debug = true;
    o.TracesSampleRate = 1.0;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSentryTracing();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
