using Microsoft.AspNetCore.Authentication;
using TenderMVC;
using TenderMVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ITenderApiClient, TenderApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5000/api/");
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
