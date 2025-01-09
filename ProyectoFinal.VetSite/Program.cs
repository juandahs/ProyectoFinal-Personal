using ProyectoFinal.Servidor;
using ProyectoFinal.VetSite.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Llamar al método de extensión para registrar servicios del proyecto servidor
builder.Services.AddCustomServices(builder.Configuration);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiración de la sesión
    options.Cookie.HttpOnly = true; // Asegurar que solo el servidor pueda acceder a la cookie de sesión
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Llama al método de inicialización de la base de datos
await app.InitializeDatabaseAsync();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.UseMiddleware<SessionMiddleware>();

app.MapRazorPages();

app.Run();
