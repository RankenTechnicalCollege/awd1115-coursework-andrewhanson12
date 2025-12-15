using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StarlightContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StarlightContext")));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "events",
    pattern: "events/",
    defaults: new { controller = "Events", action = "Index" });

app.MapControllerRoute(
    name: "event-details",
    pattern: "events/{id:int}/{slug}/",
    defaults: new { controller = "Events", action = "Details" });

app.MapControllerRoute(
    name: "event-edit",
    pattern: "events/edit/{id:int}/{slug}/",
    defaults: new { controller = "Events", action = "Edit" });

app.MapControllerRoute(
    name: "event-delete",
    pattern: "events/delete/{id:int}/{slug}/",
    defaults: new { controller = "Events", action = "Delete" });

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
