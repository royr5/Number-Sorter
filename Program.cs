using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Number_Sorter.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Number_SorterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Number_SorterContext") ?? throw new InvalidOperationException("Connection string 'Number_SorterContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NumberSorts}/{action=Index}/{id?}");

app.Run();
