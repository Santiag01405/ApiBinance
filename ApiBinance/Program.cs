using ApiBinance.Configurations;
using ApiBinance.Data;
using ApiBinance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Configurar Settings
builder.Services.Configure<BinanceSettings>(builder.Configuration.GetSection("Binance"));

// Registrar servicios personalizados
builder.Services.AddHttpClient<BinanceApiClient>();

// Agregar MVC Controllers + Views
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();

// Rutas por defecto: ahora el Dashboard es el inicio
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
