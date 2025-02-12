using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Configuration;
using SignalR.EntityLayer.Concrete;
using SignalR.UI.ApiConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddScoped<IApiConfig, ApiConfig>();
builder.Services.AddTransient<IConnectionConfiguration, ConnectionConfiguration>();
builder.Services.AddHttpClient();
builder.Services.AddMvc(x =>
{
    var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
    x.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Admin/Login/Index";
    cfg.AccessDeniedPath = "/Admin/Login/Index";
    cfg.ExpireTimeSpan = TimeSpan.FromHours(1);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePages(async x =>
{
    if (x.HttpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
    {
        x.HttpContext.Response.Redirect("/Error/NotFound404/");
    };
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
