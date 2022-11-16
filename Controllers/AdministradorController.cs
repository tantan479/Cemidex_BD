using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Data;
using Cemidex_BD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cemidex_BD.Controllers;

public class AdministradorController : Controller
{
    private readonly DataContext _db;

    public AdministradorController(DataContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.Administradores = _db.Administradores.AsNoTracking().ToList();
        return View(new Administrador());
    }

    [HttpPost]
    public IActionResult Index(Administrador administrador)
    {
        Console.WriteLine("Cheguei");
        _db.Administradores.Add(administrador);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
