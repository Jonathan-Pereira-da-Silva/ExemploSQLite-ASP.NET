using Microsoft.EntityFrameworkCore;
using ExemploSQLite.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Configurar SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite("Data Source=produtos.db"));

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produtos}/{action=Index}/{id?}");
app.Run();