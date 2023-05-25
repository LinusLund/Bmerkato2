using Bmerkato2.Contexts;
using Bmerkato2.Helpers.Repos;
using Bmerkato2.Helpers.Services;
using Bmerkato2.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Merkato")));



//Services
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<ProductCategoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ContactFormService>();

//Repositories
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<ProductCategoryRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductTagRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<ContactFormRepository>();

//Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
})

.AddEntityFrameworkStores<DataContext>()
.AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
    
});
var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "ProductAdd",
    pattern: "Products/Add",
    defaults: new { controller = "Products", action = "Add" });

app.MapControllerRoute(
    name: "Products",
    pattern: "Products/{action=Index}/{id?}",
    defaults: new { controller = "Products" });

app.MapControllerRoute(
    name: "UsersAdd",
    pattern: "admin/AddUser",
    defaults: new { controller = "admin", action = "AddUser" });

app.MapControllerRoute(
 name: "productDetails",
 pattern: "products/{articleNumber}",
 defaults: new { controller = "Products", action = "Details" });



app.Run();
