using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using SyncfusionBlazorApp1.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddJsonOptions(options =>
{
options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddMvc().AddJsonOptions(options =>
{
options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddMvc().AddJsonOptions(options =>
{
options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddMvc().AddJsonOptions(options =>
{
options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Add services to the container.
builder.Services.AddSyncfusionBlazor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<UniversityDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapDefaultControllerRoute();
app.MapFallbackToPage("/_Host");

app.Run();
