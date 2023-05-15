using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RecruiterWeb.Servicios;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//Permite el acceso de cualquier api
string cors = "ConfigurarCors";
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors, builder =>
    {
        //Permite ediciones de todo tipo
        builder.WithHeaders("*");
        //limita el acceso de la api
        builder.WithOrigins("*");
        //permite todos los metodos
        builder.WithHeaders("*");

    });
});
//AGREGAR EL SERVICIO API USUARIO, INYECCION DE DEPENDECIAS
builder.Services.AddScoped<IUsuarioAPI, UsuarioAPIServicio>();
//CONFIGURACION JWT - DESCARGADO DE LOS PAQUETES NUNGETS
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Issuer"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(cors);
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
