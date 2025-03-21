using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// ���U Controller �P View
builder.Services.AddControllersWithViews();

// ���U ApplicationDbContext �èϥ� PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();