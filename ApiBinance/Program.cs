using ApiBinance.Configurations;
using ApiBinance.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar Settings
builder.Services.Configure<BinanceSettings>(builder.Configuration.GetSection("Binance"));

// Registrar servicios personalizados
builder.Services.AddHttpClient<BinanceApiClient>();

// Agregar MVC Controllers + Views
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

// Rutas por defecto: ahora el Dashboard es el inicio
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
