using Cemidex_BD.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); // vida util do biscoito, ou seja o login expira se inativo
        options.SlidingExpiration = true; // biscoito renovavel. Sequestro de cookies
        options.AccessDeniedPath = "/Home/Proibida"; // perfis sem permissão de acesso
        options.LoginPath = "/Home/Login"; // caso ele não esteja logado por padrão sempre vem para cá
        options.LogoutPath = "/Home/Logout";
    });
builder.Services.AddHttpContextAccessor(); // permite o login a partir de uma action

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite("Data Source=data.db");
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
