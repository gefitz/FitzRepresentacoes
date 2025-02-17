using FitzRepresentacoes.Context;
using FitzRepresentacoes.DTOs.Mapper;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository;
using FitzRepresentacoes.Repository.Interfaces;
using FitzRepresentacoes.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region Cookie Configuração
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.LoginPath = new PathString("/Login/Index");
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
});
#endregion
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connection, ServerVersion.AutoDetect(connection)));
builder.Services.AddScoped<Autenticacao>();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<LogModel>();

#region Repository
builder.Services.AddScoped<IDbMethods<ClienteModel>,ClienteRepository>();
builder.Services.AddScoped<IDbMethods<UsuarioModel>, UsuariosRepository>();
builder.Services.AddScoped<IDbMethods<ProdutoModel>, ProdutoRepository>();
builder.Services.AddScoped<LogRepository>();
#endregion

#region Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ProdutoService>();
#endregion


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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

app.Run();
