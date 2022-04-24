using Microsoft.EntityFrameworkCore;
using Pomoro_Language_Learning.Models;
using Microsoft.AspNetCore.Identity;
using Pomoro_Language_Learning.Areas.Identity.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");;

builder.Services.AddDbContext<Pomoro_Language_Learning.Areas.Identity.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Pomoro_Language_Learning.Areas.Identity.Data.ApplicationDbContext>();;

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.AddControllersWithViews().AddViewLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");

    var cultures = new CultureInfo[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("de-De"),
    };

    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;

    
});



// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<Pomoro_Language_Learning.Areas.Identity.Data.ApplicationDbContext>(options => options.UseSqlServer(
 //   builder.Configuration.GetConnectionString("DefaultConnections")
//));


var app = builder.Build();
app.UseRequestLocalization();

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
