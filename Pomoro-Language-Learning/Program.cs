using Microsoft.EntityFrameworkCore;
using Pomoro_Language_Learning.Models;
using Microsoft.AspNetCore.Identity;
using Pomoro_Language_Learning.Areas.Identity.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");;

builder.Services.AddDbContext<Pomoro_Language_Learning.Areas.Identity.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Pomoro_Language_Learning.Areas.Identity.Data.ApplicationDbContext>();;

// Localization


// builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });


builder.Services.AddMvc()
        .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
        .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var culture = new List<CultureInfo> {
        new CultureInfo("en-US"),
        new CultureInfo("de-DE"),
    };
    //options.DefaultRequestCulture = new RequestCulture(culture[0]);
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = culture;
    options.SupportedUICultures = culture;
});


// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<Pomoro_Language_Learning.Areas.Identity.Data.ApplicationDbContext>(options => options.UseSqlServer(
//   builder.Configuration.GetConnectionString("DefaultConnections")
//));

// optional
builder.Services.AddRazorPages();

var app = builder.Build();
var options = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(options.Value);

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
