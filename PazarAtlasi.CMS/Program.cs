using PazarAtlasi.CMS.Persistence;
using Microsoft.AspNetCore.Identity;
using PazarAtlasi.CMS.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Infrastructure.Middleware;
using PazarAtlasi.CMS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Persistence Layer
builder.Services.AddPersistenceServiceRegistrations(builder.Configuration);
builder.Services.AddInfrastructureServiceRegistrations(builder.Configuration);

// Add Agent Marketplace Services
builder.Services.AddHttpClient<PazarAtlasi.CMS.Services.Interfaces.IN8nService, PazarAtlasi.CMS.Services.N8nService>();
builder.Services.AddScoped<PazarAtlasi.CMS.Services.Interfaces.IN8nService, PazarAtlasi.CMS.Services.N8nService>();

// Localization is now handled by LanguageService and LanguageMiddleware

var app = builder.Build();

// Localization is now handled by LanguageMiddleware

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Add Language Middleware
app.UseLanguageMiddleware();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
