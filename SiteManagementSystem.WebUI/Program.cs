using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using SiteManagementSystem.Business.Abstract;
using SiteManagementSystem.Business.Concrete;
using SiteManagementSystem.DataAccess.Abstract;
using SiteManagementSystem.DataAccess.Concrete.EntityFramework;
using SiteManagementSystem.WebUI.MapperProfiles;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextFactory<SiteManagementSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSingleton<ISiteService, SiteService>();
builder.Services.AddSingleton<IFlatService, FlatService>();
builder.Services.AddSingleton<IAuthService, AuthService>();

builder.Services.AddSingleton<ICityDal, EfCityDal>();
builder.Services.AddSingleton<IDistrictDal, EfDistrictDal>();
builder.Services.AddSingleton<ISiteDal, EfSiteDal>();
builder.Services.AddSingleton<IBlockDal, EfBlockDal>();
builder.Services.AddSingleton<IFlatDal, EfFlatDal>();
builder.Services.AddSingleton<IUserDal, EfUserDal>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(p => p.LoginPath = "/Auth/Login");
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAuthorization(x => x.AddPolicy("AdminPolicy", policy => policy.RequireClaim("IsAdmin", true.ToString())));

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SiteManagementSystemContext>();
    context.Database.Migrate();
}

app.Run();
