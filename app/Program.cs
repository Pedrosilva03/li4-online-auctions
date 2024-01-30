using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using app.Data;
using app.Terminado;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<AppStateService>();
//builder.Services.AddSingleton<>();
var appStateService = AppStateService.GetInstance();
var app = builder.Build();
appStateService.LoadState();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
