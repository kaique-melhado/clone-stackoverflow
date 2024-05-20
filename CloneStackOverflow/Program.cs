using CloneStackOverflow.Data;
using CloneStackOverflow.Extensions;
using CloneStackOverflow.Helper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CloneStackOverflowConnection");
builder.Services.AddDbContext<CloneStackOverflowContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<CloneStackOverflow.Helper.ISession, Session>();

builder.Services.AddSession(opts =>
{
    opts.IdleTimeout = TimeSpan.FromHours(8);
    opts.Cookie.HttpOnly = true;
    opts.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseCustomMiddlewares();
    app.UseHsts();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
