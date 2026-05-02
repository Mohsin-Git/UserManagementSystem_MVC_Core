using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Application.Interfaces;
using UserManagementSystem.Application.IServices;
using UserManagementSystem.Application.Mapping;
using UserManagementSystem.Application.ServiceImplementation;
using UserManagementSystem.Application.Validators;
using UserManagementSystem.Domain.Entities;
using UserManagementSystem.Infrastructure;
using UserManagementSystem.Infrastructure.ServiceImplementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<PurchaseOrderDTOValidator>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
    // Password settings
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4; // 0 rakhne se behtar hai koi choti length rakhein
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;

    // Sign-in settings
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// 2. Uske BAAD Cookie configure karein (Ek hi block mein rakhein to behtar hai)
builder.Services.ConfigureApplicationCookie(options =>
{
    // Paths
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";

    // Cookie Settings
    options.Cookie.Name = "MyAuthCookie";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

    // Expiration (Aapne 20 seconds rakha hai, testing ke liye theek hai)
    options.ExpireTimeSpan = TimeSpan.FromMinutes(55);
    options.SlidingExpiration = true;
});
 
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();  
app.UseAuthorization();   

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
