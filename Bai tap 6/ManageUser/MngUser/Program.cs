using Microsoft.EntityFrameworkCore;
using System.Configuration;
using MngUser.Models;

var builder = WebApplication.CreateBuilder(args);
string conn = builder.Configuration.GetConnectionString("Conn");
builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlServer(conn);
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

app.UseSession();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
