using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Data;
using Cemidex_BD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using static BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization;

namespace Cemidex_BD.Controllers;

public class AdministradorController : Controller
{
    private readonly DataContext _db;

    public AdministradorController(DataContext db)
    {
        _db = db;
    }

    [HttpGet][Authorize]
    public IActionResult Index()
    {
        ViewBag.Administradores = _db.Administradores.AsNoTracking().ToList();
        return View(new Administrador());
    }

    [HttpPost][Authorize]
    public IActionResult Index(Administrador administrador)
    {
        if(!ModelState.IsValid)
        {
            return View(administrador);
        }
        administrador.Senha = HashPassword(administrador.Senha, 10);

        _db.Administradores.Add(administrador);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
