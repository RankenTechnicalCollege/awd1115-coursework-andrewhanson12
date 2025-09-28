using CH06.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FaqsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FAQsCS"))); 

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
    name: "category-and-topic",
    pattern: "{controller=Home}/{action=Index}/topic/{topic?}/category/{category?}");

app.MapControllerRoute(
    name: "category",
    pattern: "{controller=Home}/{action=Index}/category/{category}");

app.MapControllerRoute(
    name: "topic",
    pattern: "{controller=Home}/{action=Index}/topic/{topic}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
