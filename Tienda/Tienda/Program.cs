using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tienda.Data;
using Tienda.Data.Entities;
using Tienda.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Para conectarme a la base de datos y llamar la conexion que tengo en el appsettings.json
builder.Services.AddDbContext<DataContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Base"));
});

//TODO: Make strongest password
//Esto es para indicarle a la plicacion como se van a coportar los usuarios.
builder.Services.AddIdentity<User, IdentityRole>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
    cfg.Password.RequireDigit = false;
    cfg.Password.RequiredUniqueChars = 0;
    cfg.Password.RequireLowercase = false;
    cfg.Password.RequireNonAlphanumeric = false;
    cfg.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/NotAuthorized";
    options.AccessDeniedPath = "/Account/NotAuthorized";
});



//Para poder hacer cambios en caliente en el Frond de la aplicacion, desde el entity7 ya no es necesario ya lo trae embebido 
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddTransient<SeedDb>();//Para ejecutar la inyeccion de datos.
builder.Services.AddScoped<IUserHelper,UserHelper>();//Para ejecutar la inyeccion del UserHelper pero le inyecto la interfas, para ver temas de pruebas unitarias
builder.Services.AddScoped<ICombosHelper, CombosHelper>();//Para ejecutar la inyeccion del CombosHelper pero le inyecto la interfas, para ver temas de pruebas unitarias

var app = builder.Build();
//Como en esta clase no se pueden hacer inyecciones de datos se hace a mano con el siguente codigo
SeedData();

void SeedData()
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service.SeedAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
