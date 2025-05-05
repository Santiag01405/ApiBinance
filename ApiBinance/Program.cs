using ApiBinance.Configurations;
<<<<<<< HEAD
using ApiBinance.Data;
using ApiBinance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
=======
using ApiBinance.Services;
>>>>>>> 69616524e48364b9a76f7dd7d4bee73fb178d9c1

var builder = WebApplication.CreateBuilder(args);

// Configurar Settings
builder.Services.Configure<BinanceSettings>(builder.Configuration.GetSection("Binance"));

// Registrar servicios personalizados
builder.Services.AddHttpClient<BinanceApiClient>();

// Agregar MVC Controllers + Views
builder.Services.AddControllersWithViews();

<<<<<<< HEAD
// Configuracion bd
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddHttpClient<BinanceApiClient>();

=======
>>>>>>> 69616524e48364b9a76f7dd7d4bee73fb178d9c1
var app = builder.Build();

// Configurar Middlewares
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

<<<<<<< HEAD
app.UseAuthentication();
=======
>>>>>>> 69616524e48364b9a76f7dd7d4bee73fb178d9c1
app.UseAuthorization();

// Rutas por defecto: ahora el Dashboard es el inicio
app.MapControllerRoute(
    name: "default",
<<<<<<< HEAD
    pattern: "{controller=Account}/{action=Login}/{id?}");
=======
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
>>>>>>> 69616524e48364b9a76f7dd7d4bee73fb178d9c1

app.Run();
