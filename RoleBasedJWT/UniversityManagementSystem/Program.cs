using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔥 SECRET KEY (centralized)
var jwtKey = "THIS_IS_A_SUPER_SECRET_KEY_123456789";

// 🔥 SERVICES
builder.Services.AddScoped<JwtService>();
builder.Services.AddHttpContextAccessor();

// 🔥 SESSION (REQUIRED FOR FIRST LOGIN FLOW)
builder.Services.AddSession();

// 🔥 DB CONNECTION
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔥 IDENTITY
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// 🔥 JWT AUTH
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey))
    };

    // 🔥 READ TOKEN FROM COOKIE
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["jwt"];
            return Task.CompletedTask;
        }
    };
});

// 🔥 MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔥 MIDDLEWARE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔥 SESSION BEFORE AUTH
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

// 🔥 ROUTES
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 🔥 SEED DATA
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "Faculty", "Student" };

    // 🔥 Create Roles
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    // 🔥 ADMIN
    var adminEmail = "admin@uni.com";
    var admin = await userManager.FindByEmailAsync(adminEmail);

    if (admin == null)
    {
        admin = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FullName = "Admin User",
            IsFirstLogin = false // admin shouldn't be forced
        };

        await userManager.CreateAsync(admin, "Admin@123");
        await userManager.AddToRoleAsync(admin, "Admin");
    }

    // 🔥 FACULTY
    var facultyEmail = "faculty@uni.com";
    var faculty = await userManager.FindByEmailAsync(facultyEmail);

    if (faculty == null)
    {
        faculty = new ApplicationUser
        {
            UserName = facultyEmail,
            Email = facultyEmail,
            FullName = "Faculty User",
            IsFirstLogin = false
        };

        await userManager.CreateAsync(faculty, "Faculty@123");
        await userManager.AddToRoleAsync(faculty, "Faculty");
    }

    // 🔥 STUDENT
    var studentEmail = "student@uni.com";
    var student = await userManager.FindByEmailAsync(studentEmail);

    if (student == null)
    {
        student = new ApplicationUser
        {
            UserName = studentEmail,
            Email = studentEmail,
            FullName = "Student User",
            IsFirstLogin = false
        };

        await userManager.CreateAsync(student, "Student@123");
        await userManager.AddToRoleAsync(student, "Student");
    }
}

app.Run();