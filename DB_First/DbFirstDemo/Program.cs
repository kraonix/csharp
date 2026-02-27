using DbFirstDemo.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EmployeeManagementContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmployeeManagement")
    ));

var app = builder.Build();

// Configure HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmployeeManagement}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();