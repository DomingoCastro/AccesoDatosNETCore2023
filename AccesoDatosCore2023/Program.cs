using AccesoDatosCore2023.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// RECUPERAMOS LA CADENA DE CONEXION DESDE APPSETTINGS
string cadenaConexion = builder.Configuration.GetConnectionString("hospitallocal");
RepositoryEmpleados repo = new RepositoryEmpleados(cadenaConexion);
RepositoryPlantilla repoplantilla = new RepositoryPlantilla(cadenaConexion);
//VAMOS A ENVIAR DIRECTAMENTE EL REPOSITORIO
builder.Services.AddTransient<RepositoryEmpleados>(z => repo);
builder.Services.AddTransient<RepositoryPlantilla>(z => repoplantilla);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
