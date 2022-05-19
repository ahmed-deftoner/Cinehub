using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Cinehub.Services;
using Syncfusion.Blazor;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTk3MTcyQDMxMzkyZTM0MmUzME50VkxER2EzWHVKWnZ1NzYzY0Q3UEdRWXRnOW5TeWhsNFNPQXdnYzlKQWM9");


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<CinehubService>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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
app.MapFallbackToPage("/_Host");

app.Run();
