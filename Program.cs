using Microsoft.EntityFrameworkCore;
using Cemidex_BD.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlite("Data Source=data.db"); // nome do arquivo onde se encontra o banco de dados
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

if(!app.Environment.IsDevelopment()){
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute(); 

app.Run();

/*
TODO: k
*/