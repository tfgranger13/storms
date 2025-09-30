using storms.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Storms.Data;
using storms.Data;

// DB context added when scaffolding the model
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<StormContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("StormContext") ?? throw new InvalidOperationException("Connection string 'StormContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Add initial HURDAT2 data to the database from ETL pipeline
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    EtlSeed.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

// minimal API for delivering Storms data
app.MapGet("/storms_api", async (StormContext db) =>
    await db.Storm.ToListAsync());

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
